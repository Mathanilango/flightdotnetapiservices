using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Searchservice.Model
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string Pnrno { get; private set; }
        public int FlightId { get; set; }
        public int AirlineId { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int BookedSeats { get; set; }
        public bool Removed { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime Dateofjourney { get; set; } = DateTime.Now;
        public DateTime TicketcancelledDate { get; set; }
    }
}
