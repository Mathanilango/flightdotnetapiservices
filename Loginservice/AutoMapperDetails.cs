using AutoMapper;
using Loginservice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservice
{
    public class AutoMapperDetails:Profile
    {
        public AutoMapperDetails()
        {
            CreateMap<UserDto, User>();
            CreateMap<LoginDto, User>();
        }
    }
}
