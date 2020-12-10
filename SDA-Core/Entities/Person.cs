using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Person
    {
        public Person()
        {
            Users = new HashSet<User>();
        }

        public string Code { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual Lookup GenderNavigation { get; set; }
        public virtual Lookup PositionNavigation { get; set; }
        public virtual Lookup TitleNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
