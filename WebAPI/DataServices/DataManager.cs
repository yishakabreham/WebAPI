using Microsoft.EntityFrameworkCore;
using SDA_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var user = !string.IsNullOrWhiteSpace(username) ? await _context.Users.FirstOrDefaultAsync(u => u.UserName == username) : null;
            return user;
        }
        #endregion
    }
}
