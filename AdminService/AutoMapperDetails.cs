using Adminservice.Dto;
using Adminservice.Model;
using AutoMapper;
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
            CreateMap<AirlineDto, Airline>();
            CreateMap<FlightDto, Flight>();
        }
    }
}
