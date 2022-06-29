using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Searchservice.Dto;
using Searchservice.Interface;
using Searchservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    //[Authorize]
    public class SearchController : ControllerBase
    {
        private readonly IMapper _Imapper;
        private readonly ISearch _Iserach;
        public SearchController(IMapper mapper, ISearch isearch)
        {
            _Imapper = mapper;
            _Iserach = isearch;
        }
        [HttpPost("searchflight")]
        public async  Task< List<Flight>>searchflight(FlightDto flightDto)
        {
            IList<Flight> flt = new List<Flight>();
            //DateTime ts = Convert.ToDateTime(flightDto.StartDate).Date;
            try
            {
               // flightDto.StartDate = ts.Date;
                var result = _Imapper.Map<FlightDto, Flight>(flightDto);
                var res = await _Iserach.SearchFlight(result);
                flt = res;
                return flt.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        [HttpGet("searchticket")]
        public List<Ticket> searchticketbypnr(string pnrno)
        {
            
            return _Iserach.GetticketByPnr(pnrno);
        }
        [HttpGet("searchemailid")]
        public List<Ticket> searchticketbyemailid(string emailid)
        {

            return _Iserach.Getticketbyemaild(emailid);
        }
        [HttpGet("testazure")]
        public string azure()
        {
            return "SearchService Deployed successfully!!";

        }
    }
}
