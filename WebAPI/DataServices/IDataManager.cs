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
        public Task<List<TripResult>> GetTrips(DateTime fromDate, DateTime toDate, string source, string destination);
        public Task<TripSeatArrangementResult> GetTripSeatArrangements(int tripCode);
        public Task<List<Configuration>> GetConfigurations();
        public Task<List<Configuration>> GetChildConfigurations();
        public Task<List<VoucherConsignee>> GetVoucherConsigneesByPhone(string phoneNo);
        public Task<Pricing> GetPricingByReferenceAndType(int reference, string type);
        #endregion

        #region Insert
        public Task<int> InsertVoucherConsignee(VoucherConsignee consignee);
        public Task<int> InsertLineItem(LineItem lineItem);
        public Task<int> InsertActivity(Activity activity);
        public Task<int> InsertVoucher(Voucher voucher);

        #endregion

        #region Updater
        public Task<bool> UpdateVoucherConsignee(VoucherConsignee consignee);
        #endregion
    }
}
