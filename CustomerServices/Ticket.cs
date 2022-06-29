using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Model
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }
        public string PNRNo { get; private set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int SeatBooked { get; set; }
        public int SeatNo { get; set; }
        public string Meal { get; set; }
        public bool Removed { get; set; }
        public DateTime Datecreated { get; set; } = DateTime.Now;
    }
}
