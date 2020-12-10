using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Activity
    {
        public string Code { get; set; }
        public string Reference { get; set; }
        public int ActivityDefinition { get; set; }
        public DateTime StartTimeStamp { get; set; }
        public DateTime? EndTimeStamp { get; set; }
        public string OrganizationUnitDefinition { get; set; }
        public string Device { get; set; }
        public string User { get; set; }
        public string Remark { get; set; }

        public virtual ActivityDefinition ActivityDefinitionNavigation { get; set; }
        public virtual OrganizationUnitDefinition OrganizationUnitDefinitionNavigation { get; set; }
    }
}
