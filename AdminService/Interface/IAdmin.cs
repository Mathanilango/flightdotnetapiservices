using Adminservice.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservice.Interface
{
    public interface IAdmin
    {
        string addairline(Airline airline);
        string addflight(Flight flight);
        string blockairline(int airlineid);
        string Unblockairline(int airlineid);
        string scheduleflight(Flight ft);
        Airline[] searchflight(int flightno);
        Airline[] getallairline();
        Flight[] getflight(int airno);
        void seatcount(string seat, IServiceScopeFactory serviceScopeFactory);

    }
}
