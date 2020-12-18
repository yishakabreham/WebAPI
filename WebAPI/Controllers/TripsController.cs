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

            if(result != null)
            {
                var resultDto = result.Select(r => new TripResult
                {
                    tripCode = r.Code,
                    source = r.RouteNavigation.SourceNavigation.Description,
                    destination = r.RouteNavigation.DestinationNavigation.Description,
                    busName = r.BusNavigation.Description,
                    date = r.Date.ToString(TICKET2020Constants.dateTimeFormat),
                    totalSeats = r.BusNavigation.SeatArrangements.Where(s => s.Type == TICKET2020Constants.SEAT).Count(),
                    availableSeats = r.LineItems.Count,
                    isExpired = DateTime.Now > r.Date
                }).ToList();

                return Ok(new { trips = resultDto });
            }
            return Ok(new { trips = result });
        }
    }
}
