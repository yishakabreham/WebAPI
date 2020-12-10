using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwBu
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string PlateNumber { get; set; }
        public string SideNumber { get; set; }
        public string Capacity { get; set; }
        public bool IsActive { get; set; }
    }
}
