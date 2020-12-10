using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class SeatArrangement
    {
        public string Code { get; set; }
        public string Reference { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Remark { get; set; }

        public virtual Bu ReferenceNavigation { get; set; }
        public virtual Lookup TypeNavigation { get; set; }
    }
}
