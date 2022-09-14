using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ALTIMETRIK.Persistence;
using System.Threading;
using AutoMapper;
using ALTIMETRIK.Application.ZipUsers.DTOMappers;

namespace ALTIMETRIKTests.Core
{
    public class BaseTest
    {
        protected ALTIMETRIKContext _context;
        protected CancellationToken token;
        protected readonly IMapper _mapper;
        public BaseTest(bool InMemory=false, ITestOutputHelper testOutputHelper=null)
        {
            if (InMemory)
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();
                var options = new DbContextOptionsBuilder<ALTIMETRIKContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .UseInternalServiceProvider(serviceProvider)
                    .Options;
                _context = new ALTIMETRIKContext(options);
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                token = cancellationTokenSource.Token;
                if (_mapper == null)
                {
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new ZipUserMapper());
                    });
                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }
            }
        }
    }
}
