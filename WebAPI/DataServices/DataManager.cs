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

        #endregion
    }
}
