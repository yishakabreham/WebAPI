using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class IdDefinition
    {
        public IdDefinition()
        {
            IdSettings = new HashSet<IdSetting>();
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public string Prefix { get; set; }
        public string PrefixSeparator { get; set; }
        public int Length { get; set; }
        public string SuffixSeparator { get; set; }
        public string Suffix { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<IdSetting> IdSettings { get; set; }
    }
}
