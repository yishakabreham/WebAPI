using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwOrgUnitDefinition
    {
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string TypeDesc { get; set; }
        public string Description { get; set; }
        public string Parent { get; set; }
        public string SpecializationCode { get; set; }
        public string SpecializationDesc { get; set; }
        public string Abbrivation { get; set; }
    }
}
