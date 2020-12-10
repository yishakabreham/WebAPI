using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwTrip
    {
        public string TripCode { get; set; }
        public string RouteCode { get; set; }
        public string RouteDesc { get; set; }
        public DateTime TripDate { get; set; }
        public string BusCode { get; set; }
        public string BusDesc { get; set; }
        public string BusTypeCode { get; set; }
        public string BusTypeDesc { get; set; }
        public int BusCapacity { get; set; }
        public string PlateNumber { get; set; }
        public string SideNumber { get; set; }
        public decimal? Discount { get; set; }
        public decimal UnitAmount { get; set; }
    }
}
