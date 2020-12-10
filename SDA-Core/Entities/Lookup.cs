using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Lookup
    {
        public Lookup()
        {
            Addresses = new HashSet<Address>();
            Devices = new HashSet<Device>();
            OrganizationUnitDefinitions = new HashSet<OrganizationUnitDefinition>();
            PersonGenderNavigations = new HashSet<Person>();
            PersonPositionNavigations = new HashSet<Person>();
            PersonTitleNavigations = new HashSet<Person>();
            RouteDestinationNavigations = new HashSet<Route>();
            RouteSourceNavigations = new HashSet<Route>();
            SeatArrangements = new HashSet<SeatArrangement>();
            Vouchers = new HashSet<Voucher>();
        }

        public string Code { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<OrganizationUnitDefinition> OrganizationUnitDefinitions { get; set; }
        public virtual ICollection<Person> PersonGenderNavigations { get; set; }
        public virtual ICollection<Person> PersonPositionNavigations { get; set; }
        public virtual ICollection<Person> PersonTitleNavigations { get; set; }
        public virtual ICollection<Route> RouteDestinationNavigations { get; set; }
        public virtual ICollection<Route> RouteSourceNavigations { get; set; }
        public virtual ICollection<SeatArrangement> SeatArrangements { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
