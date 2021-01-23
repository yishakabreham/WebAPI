﻿using Microsoft.EntityFrameworkCore;
using SDA_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Helpers;

namespace WebAPI.DataServices
{
    public class DataManager : IDataManager
    {
        TicketContext _context;
        public DataManager(TicketContext context)
        {
            _context = context;
        }

        #region Getter
        public async Task<User> GetUserByUserName(string username)
        {
            return !string.IsNullOrWhiteSpace(username) ? await _context.Users.FirstOrDefaultAsync(u => u.UserName == username) : null;
        }

        public async Task<Organization> GetOwnCompany()
        {
            return await _context.Organizations.FirstOrDefaultAsync(c => c.Type == TICKET2020Constants.TYPE_COMPANY.ToString());
        }

        public async Task<List<TripResult>> GetTrips(DateTime fromDate, DateTime toDate, string source, string destination)
        {
            //var subTrips = _context.Relations.Join(_context.Pricings,
            //                        relation => relation.Code,
            //                        price => price.Reference,
            //                        (relation, price) => new { subTrip = relation, price })
            //                .Where(s => s.subTrip.Type == TICKET2020Constants.TRIP_ROUTE_RELATION && s.subTrip.RelationLevel == TICKET2020Constants.TRIP_SUB_ROUTE_RELATION_LEVEL)
            //                .Join(_context.Routes,
            //                        relationTrips => relationTrips.subTrip.Reference,
            //                        route => route.Code,
            //                        (relationTrips, route) => new {route, relationTrips.price, mainTrip = relationTrips.subTrip.Referring });

            //var subTripsCount = from rl in _context.Relations
            //                    where rl.Type == TICKET2020Constants.TRIP_ROUTE_RELATION && rl.RelationLevel == TICKET2020Constants.TRIP_SUB_ROUTE_RELATION_LEVEL
            //                    select new {trip = rl.Referring,}

            var result = from tp in _context.Trips
                         join pr in _context.Pricings
                         on tp.Code equals pr.Reference
                         where tp.Date.Date >= fromDate.Date && tp.Date.Date <= toDate.Date                         
                         select new { trip = tp, price = pr, 
                             subTrips = _context.Relations.Where(r => r.Referring == tp.Code && r.Type == TICKET2020Constants.TRIP_ROUTE_RELATION && r.RelationLevel == TICKET2020Constants.TRIP_SUB_ROUTE_RELATION_LEVEL).Count()
                         };

            result = !string.IsNullOrWhiteSpace(source) ? result.Where(tp => tp.trip.RouteNavigation.Source == source) : result;
            result = !string.IsNullOrWhiteSpace(destination) ? result.Where(tp => tp.trip.RouteNavigation.Destination == destination) : result;
            
            return await result.Select(r => new TripResult
            {
                tripCode = r.trip.Code,
                source = r.trip.RouteNavigation.SourceNavigation.Description,
                destination = r.trip.RouteNavigation.DestinationNavigation.Description,
                sourceLocal = r.trip.RouteNavigation.SourceNavigation.Remark,
                destinationLocal = r.trip.RouteNavigation.DestinationNavigation.Remark,
                busName = r.trip.BusNavigation.Description,
                date = r.trip.Date.ToString(TICKET2020Constants.dateTimeFormat),
                totalSeats = r.trip.BusNavigation.SeatArrangements.Where(s => s.Type == TICKET2020Constants.SEAT).Count(),
                availableSeats = r.trip.LineItems.Count,
                isExpired = DateTime.Now > r.trip.Date,
                price = r.price.UnitAmount,
                discount = r.price.Discount.Value,
                subTripsCount = r.subTrips
            }).ToListAsync();
        }

        public async Task<TripSeatArrangementResult> GetTripSeatArrangements(string tripCode)
        {
            if (!string.IsNullOrWhiteSpace(tripCode))
            {
                var soldSeats = await (from trans in _context.TripTransactions
                                where trans.LineItemNavigation.Trip == tripCode &&
                                trans.LineItemNavigation.VoucherNavigation.LastObjectState != TICKET2020Constants.OSD_REFUNDED && 
                                trans.LineItemNavigation.VoucherNavigation.LastObjectState != TICKET2020Constants.OSD_EXTENDED
                                select trans.Seat).ToListAsync();

                var seatArrangements = await (from tp in _context.Trips
                                       where tp.Code == tripCode
                                       select tp.BusNavigation.SeatArrangements).FirstOrDefaultAsync();

                var busInfo = await (from tp in _context.Trips
                              join rl in _context.Relations
                              on tp.Code equals rl.Referring
                              where tp.Code == tripCode && rl.Type == TICKET2020Constants.TRIP_RELATION && (rl.RelationLevel == TICKET2020Constants.TRIP_RELATION_DRIVER || rl.RelationLevel == TICKET2020Constants.TRIP_RELATION_CODRIVER)
                              select rl).ToListAsync();

                return new TripSeatArrangementResult { soldSeats = soldSeats, 
                                                       seatArrangements = seatArrangements?.Select(a => new SeatArrangementResult
                                                       {
                                                            Code = a.Code, Name = a.Name, Type = a.Type, X = a.X, Y = a.Y
                                                       }).ToList(),
                                                       soldSeatsCount = soldSeats != null ? soldSeats.Count : 0,
                                                        busInfo = new TripBusResult 
                                                        {
                                                            code = seatArrangements?.FirstOrDefault().Reference,
                                                            name = seatArrangements?.FirstOrDefault().ReferenceNavigation.Description,
                                                            plateNo = seatArrangements?.FirstOrDefault().ReferenceNavigation.PlateNumber,
                                                            sideNo = seatArrangements?.FirstOrDefault().ReferenceNavigation.SideNumber,
                                                            driver = busInfo?.FirstOrDefault(b => b.RelationLevel == TICKET2020Constants.TRIP_RELATION_DRIVER)?.Reference,
                                                            coDrivers  = busInfo?.Where(b => b.RelationLevel == TICKET2020Constants.TRIP_RELATION_CODRIVER)?.Select(b => b.Reference).ToArray(),
                                                        },
                                                        maxX = seatArrangements != null ? seatArrangements.Max(s => s.X) : 0,
                                                        maxY = seatArrangements != null ? seatArrangements.Max(s => s.Y) : 0
                };

            }
            return null;
        }

        public async Task<List<Configuration>> GetConfigurations()
        {
            return await _context.Configurations.ToListAsync();
        }

        public async Task<List<VoucherConsignee>> GetVoucherConsigneesByPhone(string phoneNo)
        {
            return await _context.VoucherConsignees.Where(c => c.Mobile == phoneNo).ToListAsync();
        }

        #endregion
    }
}
