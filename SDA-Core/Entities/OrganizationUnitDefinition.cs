using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class OrganizationUnitDefinition
    {
        public OrganizationUnitDefinition()
        {
            Activities = new HashSet<Activity>();
            OrganizationUnits = new HashSet<OrganizationUnit>();
            RoleMappers = new HashSet<RoleMapper>();
        }

        public string Code { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Parent { get; set; }
        public string Specialization { get; set; }
        public string Abbrivation { get; set; }
        public string Remark { get; set; }

        public virtual Lookup TypeNavigation { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<OrganizationUnit> OrganizationUnits { get; set; }
        public virtual ICollection<RoleMapper> RoleMappers { get; set; }
    }
}
