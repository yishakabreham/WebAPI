using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwPersonAddress
    {
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string TypeDesc { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string TitleDesc { get; set; }
        public string PhoneNumber { get; set; }
    }
}
