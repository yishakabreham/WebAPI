﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class VwVoucherDetailView
    {
        public string VoucherCode { get; set; }
        public string Type { get; set; }
        public string TypeDesc { get; set; }
        public int ConsigneeCode { get; set; }
        public string ConsigneeFirstName { get; set; }
        public string ConsigneeMiddleName { get; set; }
        public string ConsigneeLastName { get; set; }
        public string ConsigneeMobile { get; set; }
        public DateTime IssuedDate { get; set; }
        public bool IsIssued { get; set; }
        public bool IsVoid { get; set; }
        public decimal GrandTotal { get; set; }
        public string LastObjectStateCode { get; set; }
        public int? OsdCode { get; set; }
        public string OsdDesc { get; set; }
        public string OsdColor { get; set; }
        public string LastActCode { get; set; }
        public int? ActivityDefCode { get; set; }
        public string ActivityDefDesc { get; set; }
        public string BranchCode { get; set; }
        public string BranchDesc { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceDesc { get; set; }
        public string LineItemCode { get; set; }
        public string TripCode { get; set; }
        public string RouteCode { get; set; }
        public string RouteDesc { get; set; }
        public string BusCode { get; set; }
        public string BusDesc { get; set; }
        public string SeatCode { get; set; }
        public string SeatName { get; set; }
        public decimal? UnitAmount { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Discount { get; set; }
    }
}
