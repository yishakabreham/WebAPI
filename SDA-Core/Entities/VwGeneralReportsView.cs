using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwGeneralReportsView
    {
        public string VoucherCode { get; set; }
        public string LineItemCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public int Consignee { get; set; }
        public DateTime IssuedDate { get; set; }
        public bool IsVoid { get; set; }
        public decimal GrandTotal { get; set; }
        public string VoucherType { get; set; }
        public bool IsPassangerChild { get; set; }
        public string LastObjectState { get; set; }
        public string TripCode { get; set; }
        public DateTime TripDate { get; set; }
        public string RouteCode { get; set; }
        public string BusCode { get; set; }
        public string RouteSrc { get; set; }
        public string RouteDestination { get; set; }
        public string RouteDesc { get; set; }
        public string BranchCode { get; set; }
        public string BusType { get; set; }
        public string PlateNumber { get; set; }
        public string SideNumber { get; set; }
        public string BranchDesc { get; set; }
        public decimal? UnitAmount { get; set; }
        public string RedundType { get; set; }
        public decimal? RefundAmount { get; set; }
        public string Reference { get; set; }
        public int? ChildrenDiscountPercent { get; set; }
        public decimal? ChildrenDiscountAmount { get; set; }
        public string Remark { get; set; }
    }
}
