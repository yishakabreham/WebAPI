using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Organization
    {
        public string Code { get; set; }
        public string TradeName { get; set; }
        public string BrandName { get; set; }
        public string Type { get; set; }
        public string Preference { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual Preference PreferenceNavigation { get; set; }
        public virtual TypeList TypeNavigation { get; set; }
    }
}
