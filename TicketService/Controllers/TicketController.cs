using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.Model;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpPost("{send}")]
        public ActionResult <string> snd(newtest tst)
        {
           
            
            //Producer.producer(tst);
            return "sucess";
        }
    }
}
