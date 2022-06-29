using Searchservice.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchservice.DBContext
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

        
        public DbSet<Flight> flight { get; set; }
        public DbSet<Airline> airline { get; set; }
        public DbSet<Ticket> tickets { get; set; }
       
    }
}
