using ALTIMETRIK.Application.Base.ViewModels;
using ALTIMETRIK.Persistence;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetAllZipUserQueryHandler(ALTIMETRIKContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<Dto.ZipUserDto>>> Handle(GetAllZipUserQuery request, CancellationToken cancellationToken)
        {
             var result=_context.ZipUser;
             var responseModel =new ResponseModel<List<Dto.ZipUserDto>>();
            if (result == null || result.Count() == 0)
            {
                responseModel.IsSuccess = false;
                responseModel.Message = "No content";
                responseModel.ResponseCode = 204;
               
            }else
            {
                List<Dto.ZipUserDto> resultList = _mapper.Map<List<Dto.ZipUserDto>>(result.ToList());
                responseModel.IsSuccess = true;
                responseModel.Message = "Records featched successfully.";
                responseModel.Response = resultList;
                responseModel.ResponseCode = 200;
            }
            return responseModel;
        }
    }
}
