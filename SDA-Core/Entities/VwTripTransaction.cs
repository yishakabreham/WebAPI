using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwTripTransaction
    {
        public string TripCode { get; set; }
        public string TripTransactionCode { get; set; }
        public string Bus { get; set; }
        public string LineItem { get; set; }
        public string Seat { get; set; }
        public string Type { get; set; }
    }
}
