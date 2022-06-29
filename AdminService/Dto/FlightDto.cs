using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservice.Dto
{
    public class FlightDto
    {
        public int AirlineId { get; set; }
       
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ScheduleDays { get; set; }
        public string Instrument { get; set; }
        public int BusinessSeat { get; set; }
        public int NonBusinessSeat { get; set; }
        public int TicketCost { get; set; }
        public int BusinessSeatCost { get; set; }
        public int NonBusinessSeatCost { get; set; }
        public string Couponcode { get; set; }
        public int Couponcodeamt { get; set; }

    }
}
