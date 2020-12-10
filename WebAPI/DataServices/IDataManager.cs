using SDA_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DataServices
{
    public interface IDataManager
    {
        #region Getter
        public Task<User> GetUserByUserName(string username);
        #endregion
    }
}
