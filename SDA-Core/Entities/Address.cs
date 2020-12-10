using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Address
    {
        public string Code { get; set; }
        public string Reference { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Remark { get; set; }

        public virtual Lookup TypeNavigation { get; set; }
    }
}
