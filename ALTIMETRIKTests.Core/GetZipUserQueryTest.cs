using ALTIMETRIK.Application.ZipUsers.Queries;
using ALTIMETRIK.Application.ZipUsers.ZipUserQueries;
using ALTIMETRIK.Domain.Entities;
using System;
using Xunit;

namespace ALTIMETRIKTests.Core
{
    public class GetZipUserQueryTest : BaseTest
    {
        public GetZipUserQueryTest() :base(true)
        {

        }
        [Fact]
        public void GetZipUserQueryTest1()
        {
            ZipUser zipUser = Init();
            var result = new GetZipUserQueryHandler(_context, _mapper).Handle(new GetZipUserQuery()
            {
                Id = 1
            }, token);
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.True(result.Result.IsSuccess);
            Assert.NotNull(result.Result.Response);
            Assert.Equal("Record featched successfully.", result.Result.Message);
            Assert.Equal(200, result.Result.ResponseCode);
            Assert.Equal(zipUser.Id, result.Result.Response.Id);
            Assert.Equal(zipUser.FirstName, result.Result.Response.FirstName);
            Assert.Equal(zipUser.LastName, result.Result.Response.LastName);
            Assert.Equal(zipUser.JobTitle, result.Result.Response.JobTitle);
            Assert.Equal(zipUser.Email, result.Result.Response.Email);
            Assert.Equal(zipUser.MonthlySalary, result.Result.Response.MonthlySalary);
            Assert.Equal(zipUser.MonthlyExpense, result.Result.Response.MonthlyExpense);
            Assert.Equal(zipUser.ModifiedOn, result.Result.Response.ModifiedOn);
        }

        

        [Fact]
        public void GetZipUserQueryPassInvalidIdTest1()
        {
           Init();
            var result = new GetZipUserQueryHandler(_context, _mapper).Handle(new GetZipUserQuery()
            {
                Id = 2
            }, token);
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.False(result.Result.IsSuccess);
            Assert.Null(result.Result.Response);
            Assert.Equal("Record not found.", result.Result.Message);
            Assert.Equal(404, result.Result.ResponseCode);

        }

        [Fact]
        public void GetZipUserQueryPassId0Test1()
        {
            Init();
            var result = new GetZipUserQueryHandler(_context, _mapper).Handle(new GetZipUserQuery()
            {
                Id = 0
            }, token);
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.False(result.Result.IsSuccess);
            Assert.Null(result.Result.Response);
            Assert.Equal("Must pass User Id.", result.Result.Message);
            Assert.Equal(400, result.Result.ResponseCode);
        }
        private ZipUser Init()
        {
            ZipUser zipUser = new ZipUser()
            {
                Email = "shankar@gmail.com",
                FirstName = "Shankar",
                Id = 1,
                JobTitle = "Xyz",
                LastName = "PQR",
                ModifiedOn = DateTime.Now,
                MonthlyExpense = 50000,
                MonthlySalary = 1000000,
                Phone = "91101010101010"
            };
            _context.ZipUser.Add(zipUser);
            _context.SaveChanges();
            return zipUser;
        }
    }
}
