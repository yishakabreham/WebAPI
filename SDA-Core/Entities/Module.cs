using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Module
    {
        public Module()
        {
            ActivityDefinitions = new HashSet<ActivityDefinition>();
            Licences = new HashSet<Licence>();
        }

        public int Code { get; set; }
        public string Description { get; set; }
        public string Parent { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<ActivityDefinition> ActivityDefinitions { get; set; }
        public virtual ICollection<Licence> Licences { get; set; }
    }
}
