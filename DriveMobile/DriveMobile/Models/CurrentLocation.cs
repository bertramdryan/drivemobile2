using DriveMobile.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DriveMobile.Models
{
    public class CurrentLocation
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime LocatedAt { get; set; }
        public double Bearing { get; set; }
        public double EngineHours { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Speed { get; set; }
        public double Odometer { get; set; }
        public double Fuel { get; set; }
    }


    public class Vehicle
    {
        public int Id { get; set; }

        public async static void SetKeepTruckingId(string UnitNumber )
        {
            string url = string.Format(Constants.KEEPTRUCKIN_LOOKUP_URL, UnitNumber);
            using(HttpClient client = new HttpClient())
            {

            }
        }  
    }

}
