using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Attachment
    {
        public string Code { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Remark { get; set; }
    }
}
