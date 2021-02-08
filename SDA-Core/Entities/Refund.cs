using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Refund
    {
        public int Code { get; set; }
        public string Reference { get; set; }
        public string Type { get; set; }
        public int Percent { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
    }
}
