using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Relation
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public string Reference { get; set; }
        public string Referring { get; set; }
        public string RelationLevel { get; set; }
        public string Remark { get; set; }
    }
}
