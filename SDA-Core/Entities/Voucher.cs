using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Voucher
    {
        public Voucher()
        {
            LineItems = new HashSet<LineItem>();
        }

        public string Code { get; set; }
        public string Type { get; set; }
        public int Consignee { get; set; }
        public DateTime IssuedDate { get; set; }
        public bool IsIssued { get; set; }
        public bool IsChild { get; set; }
        public bool IsVoid { get; set; }
        public decimal GrandTotal { get; set; }
        public string LastObjectState { get; set; }
        public string LastActivity { get; set; }
        public string Remark { get; set; }

        public virtual Lookup TypeNavigation { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
