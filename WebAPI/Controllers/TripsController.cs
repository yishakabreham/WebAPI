using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDA_Core.Entities;
using WebAPI.DataServices;
using WebAPI.Dtos;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TripsController : ControllerBase
    {
        IDataManager _dataManager;
        public TripsController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("getTripsByDate")]
        public async Task<IActionResult> getTrips(GetByDateRangeAndPlace filter)
        {            
            if(filter == null || string.IsNullOrWhiteSpace(filter.fromDate))
            {
                var dailyTrips = await _dataManager.GetTrips(DateTime.Now.Date, DateTime.Now.Date, null, null);
                return Ok(new { trips = dailyTrips });
            }

            var fromDate = Helper.GetDateTime(filter.fromDate);
            if (!fromDate.HasValue)
            {
                return BadRequest("Start date is required!");
            }

            DateTime? toDate;
            if (string.IsNullOrWhiteSpace(filter.toDate))
            {
                toDate = fromDate;
            }
            else
            {
                toDate = Helper.GetDateTime(filter.toDate);
                if (!toDate.HasValue)
                {
                    return BadRequest("Invalid end date!");
                }
            }

            var result = await _dataManager.GetTrips(fromDate.Value, toDate.Value, filter.source, filter.destination);

            return Ok(new { trips = result });
        }

        [HttpPost("getTripSeatArrangement")]
        public async Task<IActionResult> getTripSeatArrangement(GetByCode trip)
        {
            if (trip == null || string.IsNullOrWhiteSpace(trip.itemCode))
            {
                return BadRequest("Trip Code required!");
            }

            var result = await _dataManager.GetTripSeatArrangements(int.Parse(trip.itemCode));

            return Ok(new { result = result });
        }

        [HttpPost("getConsigneeByPhone")]
        public async Task<IActionResult> getTripConsignee(GetByCode consignee)
        {
            if (consignee == null || string.IsNullOrWhiteSpace(consignee.itemCode))
            {
                return BadRequest("Consignee Phone No. is required!");
            }

            var result = await _dataManager.GetVoucherConsigneesByPhone(consignee.itemCode);
            return Ok(new { consignees = result });
        }

        [HttpPost("saveTransaction")]
        public async Task<IActionResult> saveTransaction(BaseTransaction baseTransaction)
        {
            if(baseTransaction != null && baseTransaction.transactionElementsList != null 
                && baseTransaction.transactionElementsList.Count > 0)
            {
                var orgUnit = await _dataManager.GetOrganizationUnitByReference(baseTransaction.device);
                foreach (var item in baseTransaction.transactionElementsList)
                {
                    Pricing itemPrice;
                    var consigneeSaved = false;
                    if(item.cCode == 0 && item.cFlag == -1)//New Consignee
                    {
                        var addedConsignee = await _dataManager.InsertVoucherConsignee(new VoucherConsignee 
                        {
                            FirstName = item.cFirstName,
                            MiddleName = item.cMiddleName,
                            LastName = item.cLastName,
                            IsActive = item.cIsActive,
                            Mobile = item.cMobile,
                            Remark = item.cRemark
                        });

                        item.cCode = addedConsignee;
                        consigneeSaved = addedConsignee > 0;
                    }
                    else if (item.cCode > 0 && item.cFlag == 1)//Updated Consignee
                    {
                        consigneeSaved = await _dataManager.UpdateVoucherConsignee(new VoucherConsignee
                        {
                            FirstName = item.cFirstName,
                            MiddleName = item.cMiddleName,
                            LastName = item.cLastName,
                            IsActive = item.cIsActive,
                            Mobile = item.cMobile,
                            Remark = item.cRemark
                        });
                    }
                    else if (item.cCode > 0 && item.cFlag == 0)//Existing Consignee
                    {
                        consigneeSaved = true;
                    }

                    if (consigneeSaved)
                    {
                        var voucher = new Voucher 
                        {
                            Type = TICKET2020Constants.VOUCHER_TYPE_NORMAL,
                            Consignee = item.cCode,
                            IssuedDate = DateTime.Now,
                            IsIssued = true,
                            IsChild = item.vIsChild,
                            IsVoid = false,
                            GrandTotal = 0,
                            LastObjectState = TICKET2020Constants.OSD_PREPARED,
                            Remark = item.vRemark
                        };

                        var addedVoucher = await _dataManager.InsertVoucher(voucher);
                        if(addedVoucher > 0)
                        {
                            itemPrice = string.IsNullOrEmpty(item.lRemark)
                                ? await _dataManager.GetPricingByReferenceAndType(item.lTripCode, TICKET2020Constants.PC_TRIP_PRICE)
                                : await _dataManager.GetPricingByReferenceAndType(int.Parse(item.lRemark), TICKET2020Constants.PC_RELATION_PRICE);

                            if (itemPrice != null)
                            {
                                var childDiscount = item.vIsChild
                                    ? await GetChildRefund(itemPrice.UnitAmount)
                                    : null;


                                var lineItem = await GetLineItem(childDiscount != null 
                                                            ? itemPrice.UnitAmount - childDiscount.Amount
                                                            : itemPrice.UnitAmount,
                                                            childDiscount != null
                                                            ? childDiscount.Amount
                                                            : 0,
                                                            itemPrice.Discount);

                                lineItem.Voucher = addedVoucher;
                                lineItem.Trip = item.lTripCode;
                                lineItem.UnitAmount = itemPrice.UnitAmount;
                                lineItem.Remark = item.lRemark;

                                var addedLineItem = await _dataManager.InsertLineItem(lineItem);
                                if(addedLineItem > 0)
                                {
                                    if(childDiscount != null)
                                    {
                                        childDiscount.Reference = addedLineItem.ToString();

                                        var addedChildDiscount = await _dataManager.InsertRefund(childDiscount);
                                    }

                                    var addedTripTransaction = await _dataManager.InsertTripTrasaction(new TripTransaction { LineItem = addedLineItem, Seat = item.lSeatCode });

                                    var addedActivity = await _dataManager.InsertActivity(new Activity
                                    {
                                        ActivityDefinition = 2,
                                        Device = baseTransaction.device,
                                        EndTimeStamp = DateTime.Now,
                                        Reference = addedVoucher.ToString(),
                                        User = baseTransaction.user,
                                        StartTimeStamp = DateTime.Now,
                                        OrganizationUnitDefinition = orgUnit.OrganizationUnitDefinition
                                    });
                                    if(addedActivity > 0)
                                    {
                                        voucher.LastActivity = addedActivity;
                                        voucher.GrandTotal = lineItem.TotalAmount;
                                        var updatedVoucher = await _dataManager.UpdateVoucher()
                                    }
                                }
                            }
                            
                        }
                    }
                }
                return Ok();
            }
            return BadRequest();
        }

        private async Task<Refund> GetChildRefund(decimal normalPrice)
        {
            var childConfig = await _dataManager.GetChildConfigurations();

            if(childConfig.FirstOrDefault(c  => c.Attribute == TICKET2020Constants.PL_ENABLE_CHILDREN_POLICY).CurrentValue == "true")
            {
                int percent = int.Parse(childConfig.FirstOrDefault(c => c.Attribute == TICKET2020Constants.PL_CHILDREN_DISCOUNT_AMOUNT).CurrentValue);
                return  percent > 0 
                    ? new Refund
                    {
                        Percent = percent,
                        Amount = normalPrice - (normalPrice * (decimal)(percent / 100.00)),
                        Remark = normalPrice.ToString(),
                        Type = TICKET2020Constants.RF_TYPE_CHILD_DISCOUNT
                    } 
                    : null;
            }
            else
            {
                return null;
            }
        }

        private async Task<LineItem> GetLineItem(decimal itemPrice, decimal childDiscountAmount, decimal? itemDiscount)
        {
            var lineItem = new LineItem
            {
                Discount = itemDiscount.HasValue && itemDiscount.Value.CompareTo(0) > 0 
                        ? (itemPrice - (itemPrice * (itemDiscount.Value / 100))) + childDiscountAmount
                        : childDiscountAmount,
                Quantity = 1
            };
            lineItem.TotalAmount = itemPrice - lineItem.Discount.Value;
            return lineItem;
        }
    }
}
