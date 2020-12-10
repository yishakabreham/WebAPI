using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwVoucherActivity
    {
        public string Code { get; set; }
        public decimal GrandTotal { get; set; }
        public string IssuedDate { get; set; }
        public string User { get; set; }
        public bool IsVoid { get; set; }
    }
}
