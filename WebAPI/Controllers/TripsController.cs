using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataServices;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        IDataManager _dataManager;
        public TripsController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Authorize]
        [HttpGet("getTripsByDate")]
        public async Task<IActionResult> getTrips(GetByDateRangeAndPlace filter)
        {            
            if(filter == null || string.IsNullOrWhiteSpace(filter.fromDate))
            {
                var dailyTrips = await _dataManager.GetTrips(DateTime.Now.Date, DateTime.Now.Date, null, null);
                return Ok(new { trips = dailyTrips });
            }
            
            //var fromDate = DateTime.TryParseExact

            return Ok("Ok");
        }
    }
}
