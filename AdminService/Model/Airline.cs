using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservice.Model
{
    public class Airline
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key,Column(Order =100)]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool blocked { get; set; }
        public bool Removed { get; set; }
        public DateTime Datecreated { get; set; } = DateTime.Now;
        public ICollection<Flight> flights { get; set; }
    }
}
