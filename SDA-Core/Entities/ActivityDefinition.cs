using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class ActivityDefinition
    {
        public ActivityDefinition()
        {
            Activities = new HashSet<Activity>();
            UserPrivileges = new HashSet<UserPrivilege>();
        }

        public int Code { get; set; }
        public int Module { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual Module ModuleNavigation { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<UserPrivilege> UserPrivileges { get; set; }
    }
}
