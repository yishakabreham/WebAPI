using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Route
    {
        public Route()
        {
            Trips = new HashSet<Trip>();
        }

        public int Code { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public decimal TimeLength { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }

        public virtual Lookup DestinationNavigation { get; set; }
        public virtual Lookup SourceNavigation { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
