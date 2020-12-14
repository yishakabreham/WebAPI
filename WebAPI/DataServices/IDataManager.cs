using SDA_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;

namespace WebAPI.DataServices
{
    public interface IDataManager
    {
        #region Getter
        public Task<User> GetUserByUserName(string username);
        public Task<Organization> GetOwnCompany();
        public Task<List<Trip>> GetTrips(DateTime fromDate, DateTime toDate, string source, string destination);
        #endregion
    }
}
