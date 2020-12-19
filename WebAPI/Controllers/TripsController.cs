using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataServices;
using WebAPI.Dtos;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TripsController : ControllerBase
    {
        IDataManager _dataManager;
        public TripsController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("getTripsByDate")]
        public async Task<IActionResult> getTrips(GetByDateRangeAndPlace filter)
        {            
            if(filter == null || string.IsNullOrWhiteSpace(filter.fromDate))
            {
                var dailyTrips = await _dataManager.GetTrips(DateTime.Now.Date, DateTime.Now.Date, null, null);
                return Ok(new { trips = dailyTrips });
            }

            var fromDate = Helper.GetDateTime(filter.fromDate);
            if (!fromDate.HasValue)
            {
                return BadRequest("Start date is required!");
            }

            DateTime? toDate;
            if (string.IsNullOrWhiteSpace(filter.toDate))
            {
                toDate = fromDate;
            }
            else
            {
                toDate = Helper.GetDateTime(filter.toDate);
                if (!toDate.HasValue)
                {
                    return BadRequest("Invalid end date!");
                }
            }

            var result = await _dataManager.GetTrips(fromDate.Value, toDate.Value, filter.source, filter.destination);

            return Ok(new { trips = result });
        }

        [HttpPost("getTripSeatArrangement")]
        public async Task<IActionResult> getTripSeatArrangement(String trip)
        {
            if (string.IsNullOrWhiteSpace(trip))
            {
                return BadRequest("Trip Code required!");
            }

            var result = await _dataManager.GetTripSeatArrangements(trip);

            return Ok(new { result = result });
        }
    }
}
