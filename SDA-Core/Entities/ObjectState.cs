using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class ObjectState
    {
        public int Code { get; set; }
        public string Reference { get; set; }
        public int ObjectStateDefinition { get; set; }
        public string Remark { get; set; }

        public virtual ObjectStateDefinition ObjectStateDefinitionNavigation { get; set; }
    }
}
