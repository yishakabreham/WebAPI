using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Bu
    {
        public Bu()
        {
            SeatArrangements = new HashSet<SeatArrangement>();
            Trips = new HashSet<Trip>();
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string PlateNumber { get; set; }
        public string SideNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual Preference TypeNavigation { get; set; }
        public virtual ICollection<SeatArrangement> SeatArrangements { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
