using Microsoft.EntityFrameworkCore;
using SDA_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Helpers;

namespace WebAPI.DataServices
{
    public class DataManager : IDataManager
    {
        TicketContext _context;
        public DataManager(TicketContext context)
        {
            _context = context;            
        }

        #region Getter
        public async Task<User> GetUserByUserName(string username)
        {
            return !string.IsNullOrWhiteSpace(username) ? await _context.Users.FirstOrDefaultAsync(u => u.UserName == username) : null;            
        }

        public async Task<Organization> GetOwnCompany()
        {
            return await _context.Organizations.FirstOrDefaultAsync(c => c.Type == TICKET2020Constants.TYPE_COMPANY.ToString());
        }

        public async Task<List<Trip>> GetTrips(DateTime fromDate, DateTime toDate, string source, string destination)
        {
            var result = from tp in _context.Trips
                         where tp.Date.Date >= fromDate.Date && tp.Date.Date <= toDate.Date
                         select tp;

            result = !string.IsNullOrWhiteSpace(source) ? result.Where(tp => tp.RouteNavigation.Source == source) : result;
            result = !string.IsNullOrWhiteSpace(destination) ? result.Where(tp => tp.RouteNavigation.Destination == destination) : result;

            return await result.ToListAsync();
        }

        public async Task<TripSeatArrangementResult> GetTripSeatArrangements(string tripCode)
        {
            if (!string.IsNullOrWhiteSpace(tripCode))
            {
                var soldSeats = await (from trans in _context.TripTransactions
                                where trans.LineItemNavigation.Trip == tripCode &&
                                trans.LineItemNavigation.VoucherNavigation.LastObjectState != TICKET2020Constants.OSD_REFUNDED && 
                                trans.LineItemNavigation.VoucherNavigation.LastObjectState != TICKET2020Constants.OSD_EXTENDED
                                select trans.Seat).ToListAsync();

                var seatArrangements = await (from tp in _context.Trips
                                       where tp.Code == tripCode
                                       select tp.BusNavigation.SeatArrangements).FirstOrDefaultAsync();

                return new TripSeatArrangementResult { soldSeats = soldSeats,
                                                       seatArrangements = seatArrangements?.Select(a => new SeatArrangementResult
                                                       {
                                                            Code = a.Code, Name = a.Name, Type = a.Type, X = a.X, Y = a.Y, Reference = a.Reference
                                                       }).ToList(),
                                                       soldSeatsCount = soldSeats != null ? soldSeats.Count : 0 };

            }
            return null;
        }
        #endregion
    }
}
