using DriveMobile.Helpers;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriveMobile.Models
{
    public class Power
    {
        public string UnitNumber { get; set; }
        public string Status { get; set; }

        public static async Task<List<Power>> GetPowerUnitNumbers()
        {
            string url = string.Format(Constants.DRIVE_BASE_URL, Constants.POWER);

            var response = await App.driveClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var powerList = JsonConvert.DeserializeObject<List<Power>>(json);

            return powerList;
        }
    }


}
