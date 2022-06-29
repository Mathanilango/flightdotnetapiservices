using Bookingservice.Dto;
using Bookingservice.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingservice
{
    public class AutoMapperDetails:Profile
    {
        public AutoMapperDetails()
        {
            CreateMap<TicketDto, Ticket>();
            CreateMap<TicketDto, Passenger>();
          //  CreateMap<List<TicketDto>,List<Passenger>>();

        }
    }
}
