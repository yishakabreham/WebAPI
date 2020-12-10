using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Preference
    {
        public Preference()
        {
            Bus = new HashSet<Bu>();
            Organizations = new HashSet<Organization>();
        }

        public string Code { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public byte Index { get; set; }
        public string Value { get; set; }
        public string Parent { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<Bu> Bus { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
