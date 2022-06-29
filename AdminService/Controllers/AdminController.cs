using Adminservice.DBContext;
using Adminservice.Dto;
using Adminservice.Interface;
using Adminservice.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
   // [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _Imapper;
        private readonly IAdmin _Iadmin;
        private readonly AppDBContext _cnt;
        private readonly IServiceScopeFactory _ssf;

        public AdminController(IMapper mapper, IAdmin iadmin, AppDBContext cnt, IServiceScopeFactory sf)
        {
            _Imapper = mapper;
            _Iadmin = iadmin;
            _cnt = cnt;
            _ssf = sf;
            
        }
        [HttpPost("AddAirline"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> AddAirline(AirlineDto airlineDto)
        {
           // rabitcns rabt = new rabitcns(_Iadmin);
          //  rabt.rabbitcns();
            //rabbitmqproducer rbt = new rabbitmqproducer();
           
            //rbt.rabirprd(airlineDto.Name);
            //rabt.rabbitcns();
            var result = _Imapper.Map<AirlineDto, Airline>(airlineDto);
            return _Iadmin.addairline(result);
        }
        [HttpPost("AddFlight"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> AddFlight(FlightDto flightDto)
        {
            var result = _Imapper.Map<FlightDto, Flight>(flightDto);
            return _Iadmin.addflight(result);
        }
        [HttpGet("Searchairline"), Authorize(Roles = "Admin")]
        public async Task<Airline[]> searchairline(int airlineno)
        {

            return _Iadmin.searchflight(airlineno);
        }
        [HttpGet("getallairline"), Authorize(Roles = "Admin")]
        public async Task<Airline[]> getallairline()
        {

            return _Iadmin.getallairline();
        }
        [HttpGet("getflight"), Authorize(Roles = "Admin")]
        public async Task<Flight[]> getflight(int airlineno)
        {

            return _Iadmin.getflight(airlineno);
        }
        [HttpPost("BlockAirline"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> BlockAirline(int Flightnumber)
        {
            return _Iadmin.blockairline(Flightnumber);
        }
        [HttpPost("UnBlockAirline"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> UnBlockAirline(int Flightnumber)
        {
            return _Iadmin.Unblockairline(Flightnumber);
        }
        [HttpPost("ScheduleFlight"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> ScheduleFlight(Flight ft)
        {
            return _Iadmin.scheduleflight(ft);
        }

        [HttpGet("Seatcount"), Authorize()]
        public  void Seatcount()
        {
            //rabitcns rabt = new rabitcns(_Iadmin,_ssf);
            //rabt.rabbitcns();

            string msg = "";
            var factory = new ConnectionFactory() { Uri = new System.Uri("amqp://guest:guest@localhost:5672") };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Data",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    msg = message;
                //Console.WriteLine(" [x] Received {0}", message);
                


                };
                channel.BasicConsume(queue: "Data",
                                                autoAck: true,
                                                consumer: consumer);
            }

            if (!string.IsNullOrEmpty(msg))
            {
                //Airline air = new Airline();
                //air.Name = msg;
                // _Iadmin.seatcount(msg, _scope);
                //string str = "Geeks,For,Geeks";

                char[] spearator = { ',' };

                // using the method
                string[] strlist = msg.Split(spearator);

                int flightid = Convert.ToInt32(strlist[0]);
                int seatbooked = Convert.ToInt32(strlist[1]);
                string seattype = strlist[2];
                string strg = strlist[3];

                //using (var scope = serviceScopeFactory.CreateScope())
                //{
                //    //await Task.Delay(30000);
                //    var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
                //    var res =  dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();

                if (strg == "add" && seattype == "Bussiness")
                {

                    using (var scope = _ssf.CreateScope())
                    {
                        //await Task.Delay(30000);
                        var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
                        var res = dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();
                        res.AvailableBusinessSeat = res.AvailableBusinessSeat - seatbooked;
                        _cnt.Flight.Update(res);
                        _cnt.SaveChanges();
                    }

                }
                if (strg == "add" && seattype == "Non-Bussiness")
                {
                    using (var scope = _ssf.CreateScope())
                    {
                        //await Task.Delay(30000);
                        var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
                        var res = dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();
                        res.AvailableNonBusinessSeat = res.AvailableNonBusinessSeat - seatbooked;
                        _cnt.Flight.Update(res);
                        _cnt.SaveChanges();
                    }
                }






            }

        }
        [HttpGet("Seatcancel"), Authorize()]
        public void Seatcancel()
        {
            //cancelconsumr rabt = new cancelconsumr(_Iadmin, _ssf);
            //rabt.rabbitcns();

            string msg = "";
            var factory = new ConnectionFactory() { Uri = new System.Uri("amqp://guest:guest@localhost:5672") };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "CancelTicket",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    msg = message;
                //Console.WriteLine(" [x] Received {0}", message);
               






                };
                channel.BasicConsume(queue: "CancelTicket",
                                                autoAck: true,
                                                consumer: consumer);
            }

            if (!string.IsNullOrEmpty(msg))
            {
                //Airline air = new Airline();
                //air.Name = msg;
                // _Iadmin.seatcount(msg, _scope);

                // string str = "Geeks,For,Geeks";

                char[] spearator = { ',' };

                // using the method
                string[] strlist = msg.Split(spearator);

                int flightid = Convert.ToInt32(strlist[0]);
                int seatbooked = Convert.ToInt32(strlist[1]);
                string seattype = strlist[2];
                string strg = strlist[3];


                if (strg == "cancel" && seattype == "Bussiness")
                {
                    using (var scope = _ssf.CreateScope())
                    {
                        //await Task.Delay(30000);
                        var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
                        var res = dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();
                        res.AvailableBusinessSeat = res.AvailableBusinessSeat + seatbooked;
                        _cnt.Flight.Update(res);
                        _cnt.SaveChanges();
                    }
                }
                if (strg == "cancel" && seattype == "Non-Bussiness")
                {
                    using (var scope = _ssf.CreateScope())
                    {
                        //await Task.Delay(30000);
                        var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
                        var res = dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();

                        res.AvailableNonBusinessSeat = res.AvailableNonBusinessSeat + seatbooked;
                        _cnt.Flight.Update(res);
                        _cnt.SaveChanges();
                    }
                }
            }
        }


        [HttpGet("testazure")]
        public string azure()
        {
            return "Service Deployed successfully!!";

        }
    }
 
}
