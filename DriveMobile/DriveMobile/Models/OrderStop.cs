using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMobile.Models
{
    public class OrderStop
    {
        public long OrderId { get; set; }
        public int StopNumber { get; set; }
        public string LocationName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string StopTypeName { get; set; }

        public long? DispatchLoadId { get; set; } 
        public bool? ReturnToRoad { get; set; } // If load is completed and this is true, return the load to 'On the Road' status- otherwise just generate a paysheet entry
    }
}
