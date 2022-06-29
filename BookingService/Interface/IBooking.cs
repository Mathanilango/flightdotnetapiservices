using Bookingservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingservice.Interface
{
   public interface IBooking
    {
        string BookTicket(Ticket ticket, List<Passenger> pass);
        string CancelTicket(string Pnrno);
        string ticketpdf(string id);
    }
}
