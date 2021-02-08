using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class TripTransaction
    {
        public int Code { get; set; }
        public int LineItem { get; set; }
        public string Seat { get; set; }
        public string Remark { get; set; }

        public virtual LineItem LineItemNavigation { get; set; }
        public virtual SeatArrangement SeatNavigation { get; set; }
    }
}
