﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class LineItem
    {
        public LineItem()
        {
            TripTransactions = new HashSet<TripTransaction>();
        }

        public string Code { get; set; }
        public string Voucher { get; set; }
        public string Trip { get; set; }
        public decimal? UnitAmount { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remark { get; set; }

        public virtual Voucher VoucherNavigation { get; set; }
        public virtual ICollection<TripTransaction> TripTransactions { get; set; }
    }
}
