using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingservice.Dto
{
    public class TicketDto
    {
        public int FlightId { get; set; }
        public int AirlineId { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }
        public int Seatno { get; set; }
        public int amountpaided { get; set; }
        public int BookedSeats { get; set; }
        public string seattype { get; set; }
        public string Meal { get; set; }
        public DateTime Dateofjourney { get; set; }
    }
}
