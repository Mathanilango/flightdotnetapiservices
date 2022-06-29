using Searchservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchservice.Interface
{
   public interface ISearch
    {
         Task<List<Flight>> SearchFlight(Flight flight);
        List<Ticket >GetticketByPnr(string Pnrno);
        List<Ticket> Getticketbyemaild(string emailid);
    }
}
