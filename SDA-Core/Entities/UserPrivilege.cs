using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class UserPrivilege
    {
        public string Code { get; set; }
        public string Role { get; set; }
        public int ActivityDefinition { get; set; }
        public string Remark { get; set; }

        public virtual ActivityDefinition ActivityDefinitionNavigation { get; set; }
    }
}
