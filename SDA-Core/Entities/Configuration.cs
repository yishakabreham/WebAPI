using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Configuration
    {
        public string Code { get; set; }
        public string Preference { get; set; }
        public int Reference { get; set; }
        public string Attribute { get; set; }
        public string CurrentValue { get; set; }
        public string Remark { get; set; }
    }
}
