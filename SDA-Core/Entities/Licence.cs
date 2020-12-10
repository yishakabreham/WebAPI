using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Licence
    {
        public string Code { get; set; }
        public int Reference { get; set; }
        public string Licence1 { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual Module ReferenceNavigation { get; set; }
    }
}
