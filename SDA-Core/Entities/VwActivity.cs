using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwActivity
    {
        public string Code { get; set; }
        public string Reference { get; set; }
        public int ActivityDefinition { get; set; }
        public string ActivityDefinitionDesc { get; set; }
        public string OrganizationUnitDefinition { get; set; }
        public string OrganizationUnitDefnDesc { get; set; }
        public DateTime StartTimeStamp { get; set; }
        public DateTime? EndTimeStamp { get; set; }
        public string Device { get; set; }
        public string DeviceName { get; set; }
        public string User { get; set; }
        public string UserName { get; set; }
        public string Remark { get; set; }
        public string Person { get; set; }
    }
}
