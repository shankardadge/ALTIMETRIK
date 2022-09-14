using ALTIMETRIK.Application.ZipUsers.Dto;
using ALTIMETRIK.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALTIMETRIK.Application.ZipUsers.DTOMappers
{
    public class ZipUserMapper : Profile
    {
        public ZipUserMapper()
        {
            CreateMap<ZipUser,ZipUserDto>();
        }
    }
}
