using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class OrganizationUnit
    {
        public int Code { get; set; }
        public string Reference { get; set; }
        public int OrganizationUnitDefinition { get; set; }
        public string Remark { get; set; }

        public virtual OrganizationUnitDefinition OrganizationUnitDefinitionNavigation { get; set; }
    }
}
