using DriveMobile.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriveMobile.Models
{
    public class Manifest
    {
        public int DriverId { get; set; }
        public object PowerId { get; set; }
        public int DivisionId { get; set; }
        public int Status { get; set; }
        public DateTime EstimatedStartTime { get; set; }
        public bool IsRouteComplete { get; set; }
        public bool IsBeingDetained { get; set; }
        public int LoadTypeId { get; set; }
        public int PadCount { get; set; }
        public int StrapCount { get; set; }
        public int BarCount { get; set; }
        public int DeckingCount { get; set; }
        public bool NeedsBlocking { get; set; }
        public object TrailerNumber { get; set; }
        public IList<Stop> Stops { get; set; }

        public int Id { get; set; }


        public static async Task<List<Manifest>> GetManifests() 
        {
            List<Manifest> manifestList = new List<Manifest>();

            string url = string.Format(Constants.DRIVE_BASE_URL, Constants.MANIFEST);

            

            return manifestList;
        }

    }

 


}
