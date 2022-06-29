using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchservice.Dto
{
    public class FlightDto
    {
        public int Flightnumber { get; set; }
        
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
