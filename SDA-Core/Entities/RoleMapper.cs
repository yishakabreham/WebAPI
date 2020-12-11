using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class RoleMapper
    {
        public string Code { get; set; }
        public string User { get; set; }
        public string Role { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Remark { get; set; }

        public virtual OrganizationUnitDefinition RoleNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
    }
}
