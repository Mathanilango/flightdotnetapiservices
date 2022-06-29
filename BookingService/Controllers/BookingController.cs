using AutoMapper;
using Bookingservice.Dto;
using Bookingservice.Interface;
using Bookingservice.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
   //[Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IMapper _Imapper;
        private readonly IBooking _Ibooking;

        public BookingController(IMapper mapper, IBooking ibooking)
        {
            _Imapper = mapper;
            _Ibooking = ibooking;
           
        }
        [HttpGet("testazure")]
        public string azure()
        {
            return "BookingService Deployed successfully!!";

        }
        [HttpPost("bookticket")]
        public async Task<IActionResult> Bookticket(  Ticketlist ticketDto)
        {
            TicketDto tckdt = new TicketDto();
            tckdt = ticketDto.ticketDtos.FirstOrDefault();
            var tick = _Imapper.Map<TicketDto, Ticket>(tckdt);
           var passg = _Imapper.Map<List<TicketDto>, List<Passenger> >(ticketDto.ticketDtos);
            
            _Ibooking.BookTicket(tick, passg);
           




            return Ok();
        }
        [HttpPost("cancelticket")]
        public async Task<IActionResult> Cancelticket(string pnrno)
        {
            
           var ts = _Ibooking.CancelTicket(pnrno);
            return Ok();
            
        }

        [HttpPost("downloadticket")]
        public string downloadtiscket(string pnrno)
        {

            return _Ibooking.ticketpdf(pnrno);

        }
    }
}
