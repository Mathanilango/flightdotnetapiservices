using Bookingservice.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingservice.DBContext
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected  override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(c => c.Pnrno)
                .HasComputedColumnSql("N'PNR'+ RIGHT('00000'+CAST(ID AS VARCHAR(5)),5)");
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Passenger> passengers { get; set; }

        public DbSet<Flight> Flight { get; set; }
        public DbSet<Airline> Airline { get; set; }

    }
}
