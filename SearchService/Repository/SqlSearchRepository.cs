
using LinqKit;
using Searchservice.DBContext;
using Searchservice.Interface;
using Searchservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace Searchservice.Repository
{
    public class SqlSearchRepository : ISearch
    {
        private readonly AppDBContext _context;
        public SqlSearchRepository(AppDBContext Context)
        {
            _context = Context;
        }
        //get by emailid
        public List<Ticket> Getticketbyemaild(string emailid)
        {
            try
            {
              return  _context.tickets.Where(t => t.Email == emailid && !t.Removed).ToList();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //get by pnrno
        public List<Ticket> GetticketByPnr(string Pnrno)
        {
            try
            {
                return _context.tickets.Where(t => t.Pnrno == Pnrno && !t.Removed).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //search flight
        public async Task<List<Flight>> SearchFlight(Flight flight)
        {
            var predicate = PredicateBuilder.New<Flight>();
            if (flight.Flightnumber != 0)
            {
                predicate = predicate.And(f => f.Flightnumber == flight.Flightnumber);
            }
            if (!string.IsNullOrEmpty(flight.FromPlace))
            {
                predicate = predicate.And(f => f.FromPlace == flight.FromPlace);
            }
            if (!string.IsNullOrEmpty(flight.ToPlace))
            {
                predicate = predicate.And(f => f.ToPlace == flight.ToPlace);
            }
            if (!string.IsNullOrEmpty (flight.StartDate.ToString()))
            {
                predicate = predicate.And(f => f.StartDate.Value.Date == flight.StartDate.Value.Date);
            }
            if (!string.IsNullOrEmpty(flight.EndDate.ToString()))
            {
                predicate = predicate.And(f => f.EndDate.Value.Date == flight.EndDate.Value.Date);
            }
            return _context.flight.Where(predicate).ToList();
        }
    }
}
