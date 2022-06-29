using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingservice.Model
{
    public class Flight
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 100)]
        public int Flightnumber { get; set; }
        [ForeignKey("Airline")]
        public int AirlineId { get; set; }
        public Airline Airline { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ScheduleDays { get; set; }
        public bool RoundTrip { get; set; }
        public string Instrument { get; set; }
        public int BusinessSeat { get; set; }
        public int NonBusinessSeat { get; set; }
        public int AvailableBusinessSeat { get; set; }
        public int AvailableNonBusinessSeat { get; set; }
        public string Couponcode { get; set; }
        public int Couponcodeamt { get; set; }
        public int TicketCost { get; set; }
        public int BusinessSeatCost { get; set; }
        public int NonBusinessSeatCost { get; set; }
        public bool Removed { get; set; }
        public DateTime Datecreated { get; set; } = DateTime.Now;
    }
}
