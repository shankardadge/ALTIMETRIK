using ALTIMETRIK.Application.Base.ViewModels;
using ALTIMETRIK.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALTIMETRIK.Application.ZipUsers.Queries
{

    public class GetAllZipUserQuery : IRequest<ResponseModel<List<Dto.ZipUserDto>>>
    {

    }
    public class GetAllZipUserQueryHandler : IRequestHandler<GetAllZipUserQuery, ResponseModel<List<Dto.ZipUserDto>>>
    {
        private readonly ALTIMETRIKContext _context;
        public GetAllZipUserQueryHandler(ALTIMETRIKContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<Dto.ZipUserDto>>> Handle(GetAllZipUserQuery request, CancellationToken cancellationToken)
        {
             var result=_context.ZipUser;
            if(result == null || result.Count() == 0)
            {
                return new ResponseModel<List<Dto.ZipUserDto>>()
                {
                    IsSuccess=false,
                    Message="No content",
                    ResponseCode=204
                };
            }else
            {
                 List<Dto.ZipUserDto> resultList = new List<Dto.ZipUserDto>();
                foreach(var item in result)
                {
                    resultList.Add(new Dto.ZipUserDto()
                    {
                        Email=item.Email,
                        FirstName=item.FirstName,   
                        LastName=item.LastName,
                        Id=item.Id, 
                        JobTitle=item.JobTitle,
                        MonthlyExpense=item.MonthlyExpense,
                        MonthlySalary=item.MonthlySalary,
                        Phone=item.Phone,
                    });
                }
                return new ResponseModel<List<Dto.ZipUserDto>>()
                {
                    IsSuccess = true,
                    Message = "Records featched successfully.",
                    Response= resultList,
                    ResponseCode = 200
                };
            }
        }
    }
}
