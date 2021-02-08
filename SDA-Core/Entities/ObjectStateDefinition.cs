using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class ObjectStateDefinition
    {
        public ObjectStateDefinition()
        {
            ObjectStates = new HashSet<ObjectState>();
            Trips = new HashSet<Trip>();
            Vouchers = new HashSet<Voucher>();
        }

        public int Code { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<ObjectState> ObjectStates { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
