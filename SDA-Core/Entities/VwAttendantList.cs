using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwAttendantList
    {
        public string VoucherCode { get; set; }
        public DateTime IssuedDate { get; set; }
        public int ConsigneeCode { get; set; }
        public string ConsigneeFirstName { get; set; }
        public string ConsigneeMiddleName { get; set; }
        public string ConsigneeLastName { get; set; }
        public string ConsigneeMobile { get; set; }
        public string TripCode { get; set; }
        public DateTime TripDate { get; set; }
        public string RouteCode { get; set; }
        public string BusCode { get; set; }
        public string SeatCode { get; set; }
        public string SeatName { get; set; }
    }
}
