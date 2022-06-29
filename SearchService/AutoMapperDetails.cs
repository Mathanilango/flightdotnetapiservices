using Searchservice.Dto;
using Searchservice.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchservice
{
    public class AutoMapperDetails:Profile
    {
        public AutoMapperDetails()
        {
            CreateMap<FlightDto, Flight>();
           
        }
    }
}
