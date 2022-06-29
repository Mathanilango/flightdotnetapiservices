using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerServices.Model
{
    public class FlightBooking
    {
        public int FlightId { get; set; }
        public int AirlineId { get; set; }
        public string PassengerName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int BookedSeats { get; set; }
        public string Meal { get; set; }
    }
}
