using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwLineItemObject
    {
        public string LineItemCode { get; set; }
        public string VoucherCode { get; set; }
        public string TripCode { get; set; }
        public string RouteCode { get; set; }
        public string RouteDesc { get; set; }
        public string BusCode { get; set; }
        public string BusDesc { get; set; }
        public string SeatCode { get; set; }
        public string SeatName { get; set; }
        public decimal? UnitAmount { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Discount { get; set; }
    }
}
