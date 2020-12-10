using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Pricing
    {
        public string Code { get; set; }
        public string Reference { get; set; }
        public decimal UnitAmount { get; set; }
        public decimal? Discount { get; set; }
        public string Remark { get; set; }
    }
}
