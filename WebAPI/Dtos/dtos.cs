using SDA_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class dtos
    {
    }

    public class LoginData
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class GetByCode
    {
        public string itemCode { get; set; }  //Object Code
    }

    public class GetByDateRangeAndPlace
    {
        //public string id { get; set; }  //Organization TIN
        public string fromDate { get; set; }  //Start Date
        public string toDate { get; set; }  //End Date
        public string source { get; set; }  //End Date
        public string destination { get; set; }  //End Date
    }

    //Results
    public class TripResult
    {
        public int tripCode { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; }
        public string busName { get; set; }
        public string date { get; set; }
        public int availableSeats { get; set; }
        public bool isExpired { get; set; }
        public int totalSeats { get; set; }
        public string sourceLocal { get; set; }
        public string destinationLocal { get; set; }
        public int subTripsCount { get; set; }
    }

    public class BusResult
    {
        public int MyProperty { get; set; }
    }

    public class TripSeatArrangementResult
    {
        public int soldSeatsCount { get; set; }
        public List<string> soldSeats { get; set; }
        public List<SeatArrangementResult> seatArrangements { get; set; }
        public int maxX { get; set; }
        public int maxY { get; set; }
        public TripBusResult busInfo { get; set; }
        public List<SubTripsResult> subTrips { get; set; }
    }

    public class SeatArrangementResult
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Remark { get; set; }
    }

    public class SubTripsResult
    {
        public int tripCode { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; }
        public string sourceLocal { get; set; }
        public string destinationLocal { get; set; }
    }

    public class TripBusResult
    {
        public string code { get; set; }
        public string name { get; set; }
        public string plateNo { get; set; }
        public string sideNo { get; set; }
        public string driver { get; set; }
        public string[] coDrivers { get; set; }
    }

    public class ConfigurationResult
    {
        public int Reference { get; set; }
        public string Attribute { get; set; }
        public string CurrentValue { get; set; }
    }

    //Save
    public class TransactionElements
    {
        public string vRemark { get; set; }
        public bool vIsChild { get; set; }

        public int lTripCode { get; set; }
        public string lSeatCode { get; set; }
        public string lRemark { get; set; }

        public int cCode { get; set; }
        public string cFirstName { get; set; }
        public string cMiddleName { get; set; }
        public string cLastName { get; set; }
        public bool cIsActive { get; set; }
        public string cMobile { get; set; }
        public string cRemark { get; set; }
        public int cFlag { get; set; }
    }

    public class BaseTransaction
    {
        public BaseTransaction()
        {
            transactionElementsList = new List<TransactionElements>();
        }
        public string device { get; set; }
        public string user { get; set; }
        public List<TransactionElements> transactionElementsList { get; set; };        
    }
}
