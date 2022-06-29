using Adminservice.Interface;
using Adminservice.Model;
using Adminservice.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Adminservice.Repository
{
    public class SqlAdminRepository : IAdmin
    {
        private readonly AppDBContext _context;
        public SqlAdminRepository(AppDBContext Context)
        {
            _context = Context;
        }

        //Add new Airline
        public string addairline(Airline airline)
        {
            string result;
            try
            {
                _context.Airline.Add(airline);
                _context.SaveChanges();

                result = "Created Sucessfully";
            }
            catch (Exception e)
            {
                result = "create Failed";
            }
            return result;
        }

        //Add new Flight
        public string addflight(Flight flight)
        {
            string result;
            try
            {
                var flt = _context.Airline.FirstOrDefault(a => a.ID == flight.AirlineId);
                if (flt != null)
                {
                    flight.AirlineId = flt.ID;
                    flight.AvailableBusinessSeat = flight.BusinessSeat;
                    flight.AvailableNonBusinessSeat = flight.NonBusinessSeat;
                    _context.Flight.Add(flight);
                    _context.SaveChanges();

                    result = "Created Sucessfully";
                }
                else
                {
                    result = "Airline not found, please verify airlineid";
                }
            }
            catch (Exception e)
            {
                result = "create Failed";
            }
            return result;
        }
        //block airline
        public string blockairline(int airlineid)
        {
            string result;
            try
            {
                var res = _context.Airline.FirstOrDefault(a => a.ID == airlineid);

                if (res != null)
                {
                    res.blocked = true;
                    _context.Airline.Update(res);
                    _context.SaveChanges();
                    result = "Blocked Sucessfully!!";
                }
                else
                {
                    result = "Airline not found";
                }
            }
            catch (Exception e)
            {
                result = "Update Failed";
            }
            return result;
        }
        //block airline
        public string Unblockairline(int airlineid)
        {
            string result;
            try
            {
                var res = _context.Airline.FirstOrDefault(a => a.ID == airlineid);

                if (res != null)
                {
                    if (res.blocked)
                    {
                        res.blocked = false;
                        _context.Airline.Update(res);
                        _context.SaveChanges();
                        result = "UnBlocked Sucessfully!!";
                    }
                    else
                    {
                        result = "Airline already unblocked";
                    }
                }
                else
                {
                    result = "Airline not found";
                }
            }
            catch (Exception e)
            {
                result = "Update Failed";
            }
            return result;
        }
        //Schedule Flight
        public string scheduleflight(Flight ft)
        {
            string result;
            try
            {
                var res = _context.Flight.FirstOrDefault(f => f.Flightnumber == ft.Flightnumber);
                if (res != null)
                {
                    res.BusinessSeat = ft.BusinessSeat;
                    res.NonBusinessSeat = ft.NonBusinessSeat;
                    res.StartDate = ft.StartDate;
                    res.EndDate = ft.EndDate;
                    res.ScheduleDays = ft.ScheduleDays;
                    res.TicketCost = ft.TicketCost;
                    res.Instrument = ft.Instrument;
                    res.FromPlace = ft.FromPlace;
                    res.ToPlace = ft.ToPlace;
                    res.AvailableBusinessSeat = ft.BusinessSeat;
                    res.AvailableNonBusinessSeat = ft.NonBusinessSeat;
                    res.BusinessSeatCost = ft.BusinessSeatCost;
                    res.NonBusinessSeatCost = ft.NonBusinessSeatCost;
                    res.Couponcode = ft.Couponcode;
                    res.Couponcodeamt = ft.Couponcodeamt;

                    // res.ScheduleDays = schedule;
                    _context.Flight.Update(res);
                    _context.SaveChanges();

                    result = "Scheduled sucessfully!!";
                }
                else
                {
                    result = "Flight not Found";
                }

            }
            catch (Exception e)
            {
                result = "Update failed";
            }
            return result;
        }

        public Airline[] searchflight(int flightno)
        {
            Airline[] result;
            try
            {
                result = _context.Airline.Where(a => a.ID == flightno).ToArray();

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public Airline[] getallairline()
        {
            Airline[] result;
            try
            {
                result = _context.Airline.ToArray();

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public Flight[] getflight(int airno)
        {
            Flight[] result;
            try
            {
                result = _context.Flight.Where(f => f.AirlineId == airno).ToArray();

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public async void seatcount(string seat, IServiceScopeFactory serviceScopeFactory)
        {

            string str = "Geeks,For,Geeks";

            char[] spearator = { ',' };

            // using the method
            string[] strlist = seat.Split(spearator);

            int flightid = Convert.ToInt32(strlist[0]);
            int seatbooked = Convert.ToInt32(strlist[1]);
            string seattype = strlist[2];
            string strg = strlist[3];

            //using (var scope = serviceScopeFactory.CreateScope())
            //{
            //    //await Task.Delay(30000);
            //    var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
            //    var res =  dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();

            if (strg == "add")
            {
                if (seattype == "Bussiness")
                {
                    using (var scope = serviceScopeFactory.CreateScope())
                    {
                        //await Task.Delay(30000);
                        var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
                        var res = dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();
                        res.AvailableBusinessSeat = res.AvailableBusinessSeat - seatbooked;
                        _context.Flight.Update(res);
                        _context.SaveChanges();
                    }
                }
            }
            if (seattype == "Non-Bussiness")
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    //await Task.Delay(30000);
                    var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
                    var res = dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();
                    res.AvailableNonBusinessSeat = res.AvailableNonBusinessSeat - seatbooked;
                    _context.Flight.Update(res);
                    _context.SaveChanges();
                }
            }
        
            if(strg=="cancel")
            {
                if (seattype == "Bussiness")
                {
             using (var scope = serviceScopeFactory.CreateScope())
            {
                //await Task.Delay(30000);
                var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
        var res = dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();
        res.AvailableBusinessSeat = res.AvailableBusinessSeat + seatbooked;
                    _context.Flight.Update(res);
                    _context.SaveChanges();
                  }
                }
                if (seattype == "Non-Bussiness")
                {
                    using (var scope = serviceScopeFactory.CreateScope())
                    {
                        //await Task.Delay(30000);
                        var dbContext = scope.ServiceProvider.GetService<AppDBContext>();
                        var res = dbContext.Flight.Where(f => f.Flightnumber == flightid).FirstOrDefault();

                        res.AvailableNonBusinessSeat = res.AvailableNonBusinessSeat + seatbooked;
                    _context.Flight.Update(res);
                    _context.SaveChanges();
                    }
                }
            }
           
        }

    
    }
}
