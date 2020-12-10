using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class IdSetting
    {
        public string Code { get; set; }
        public string Reference { get; set; }
        public string IdDefinition { get; set; }
        public int StartFrom { get; set; }
        public int CurrentValue { get; set; }
        public string Remark { get; set; }

        public virtual IdDefinition IdDefinitionNavigation { get; set; }
        public virtual TypeList ReferenceNavigation { get; set; }
    }
}
