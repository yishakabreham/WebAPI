using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Temporary
    {
        public int Code { get; set; }
        public string Reference { get; set; }
        public string Value { get; set; }
        public string Remark { get; set; }
    }
}
