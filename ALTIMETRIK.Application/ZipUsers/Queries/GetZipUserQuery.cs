using ALTIMETRIK.Application.Base.ViewModels;
using ALTIMETRIK.Application.ZipUsers.Dto;
using ALTIMETRIK.Domain.Entities;
using ALTIMETRIK.Persistence;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetZipUserQueryHandler(ALTIMETRIKContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseModel<Dto.ZipUserDto>> Handle(GetZipUserQuery request, CancellationToken cancellationToken)
        {
            var responseModel = new ResponseModel<Dto.ZipUserDto>();
            if (request.Id == 0)
            {
                responseModel.IsSuccess = false;
                responseModel.Message = "Must pass User Id.";
                responseModel.ResponseCode = 400;
                return responseModel;
            }
            ZipUser result = _context.ZipUser.FirstOrDefault(x => x.Id == request.Id);
            if (result != null)
            {
                var zipUser = _mapper.Map<Dto.ZipUserDto>(result);
                responseModel.IsSuccess = true;
                responseModel.Message = "Record featched successfully.";
                responseModel.ResponseCode = 200;
                responseModel.Response = zipUser;
            }
            else
            {
                responseModel.IsSuccess = false;
                responseModel.Message = "Record not found.";
                responseModel.ResponseCode = 404;
            }
           return responseModel;
        }
    }
}
