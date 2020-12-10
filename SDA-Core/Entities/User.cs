using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class User
    {
        public string Code { get; set; }
        public string Person { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? LoggedInStatus { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual Person PersonNavigation { get; set; }
    }
}
