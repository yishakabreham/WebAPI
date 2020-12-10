using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class TypeList
    {
        public TypeList()
        {
            IdSettings = new HashSet<IdSetting>();
            Organizations = new HashSet<Organization>();
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool? IsActive { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<IdSetting> IdSettings { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
