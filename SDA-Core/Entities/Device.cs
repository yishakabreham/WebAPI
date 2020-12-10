using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Device
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual Lookup TypeNavigation { get; set; }
    }
}
