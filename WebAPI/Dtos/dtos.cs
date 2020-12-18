using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class dtos
    {
    }

    public class GetByCode
    {
        public string id { get; set; }  //Organization TIN
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
        public string tripCode { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public double price { get; set; }
        public string busName { get; set; }
        public string date { get; set; }
    }
}
