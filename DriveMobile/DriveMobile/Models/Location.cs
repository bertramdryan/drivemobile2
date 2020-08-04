using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMobile.Models
{
    public class Location
    {
        public string LocationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
