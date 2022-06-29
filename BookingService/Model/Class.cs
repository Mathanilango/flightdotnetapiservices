using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingservice.Model
{
    public class Class
    {
        [Key]
        public int id { get; set; }
        public string PNR { get; set; }

    }
}
