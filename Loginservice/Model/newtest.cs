using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Model
{
    public class newtest
    {
        [Key]
        public int ID { get; set; }
        public int number { get; set; }
        public string Name { get; set; }
    }
}
