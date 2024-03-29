﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class Trip
    {
        public Trip()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int Code { get; set; }
        public int Route { get; set; }
        public string Bus { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string LastActivity { get; set; }
        public int? ObjectState { get; set; }
        public string Remark { get; set; }

        public virtual Bu BusNavigation { get; set; }
        public virtual ObjectStateDefinition ObjectStateNavigation { get; set; }
        public virtual Route RouteNavigation { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
