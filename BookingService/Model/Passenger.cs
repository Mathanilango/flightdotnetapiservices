using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingservice.Model
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        public string Pnrno { get;  set; }
        public string name { get; set; }
        public int age { get; set; }

        public string Email { get; set; }
        public string Meal { get; set; }
        public string Gender { get; set; }
        public int Seatno { get; set; }
        public string seattype { get; set; }
        public bool removed { get; set; }
        public DateTime dateofjourney { get; set; }
        public DateTime datecreated { get; set; }
    }
}
