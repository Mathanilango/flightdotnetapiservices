using Adminservice.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservice.DBContext
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
       

        public DbSet<Flight> Flight { get; set; }
        public DbSet<Airline> Airline { get; set; }
       
    }
}
