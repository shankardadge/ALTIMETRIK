using ALTIMETRIK.Application.Base.ViewModels;
using ALTIMETRIK.Application.ZipUsers.Dto;
using ALTIMETRIK.Domain.Entities;
using ALTIMETRIK.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALTIMETRIK.Application.ZipUsers.ZipUserQueries
{
    public class GetZipUserQuery : IRequest<ResponseModel<Dto.ZipUserDto>>
    {
        public long Id { get; set; }    
       
    }
    public class GetZipUserQueryHandler : IRequestHandler<GetZipUserQuery, ResponseModel<Dto.ZipUserDto>>
    {
        private readonly ALTIMETRIKContext _context;
        public GetZipUserQueryHandler(ALTIMETRIKContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<Dto.ZipUserDto>> Handle(GetZipUserQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                return  new ResponseModel<Dto.ZipUserDto>()
                {
                    IsSuccess = false,
                    Message= "Must pass User Id",
                    ResponseCode=400,
                };
            }
           ZipUser result =_context.ZipUser.FirstOrDefault(x => x.Id == request.Id);
            if (result != null)
            {
                var zipUser = new Dto.ZipUserDto()
                {
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Email = result.Email,
                    Phone = result.Phone,
                    MonthlySalary = result.MonthlySalary,
                    Id = request.Id,
                    JobTitle = result.JobTitle,
                    MonthlyExpense=result.MonthlyExpense,
                };
                return new ResponseModel<Dto.ZipUserDto>()
                {
                    IsSuccess = true,
                    Message = "Record featched successfully.",
                    ResponseCode = 200,
                    Response = zipUser
                };
            }
            else
            {
                return new ResponseModel<Dto.ZipUserDto>()
                {
                    IsSuccess = false,
                    Message = "Record not found",
                    ResponseCode = 404,
                };
            }
        }
    }
}
