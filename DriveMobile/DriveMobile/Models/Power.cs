using DriveMobile.Helpers;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DriveMobile.Models
{
    public class Power
    {
        public int Id { get; set; }
        public string UnitNumber { get; set; }
        public string LastLocation { get; set; }
        public string Status { get; set; }

        public static async Task<List<Power>> GetPowerUnitNumbers()
        {
            string url = string.Format(Constants.DRIVE_BASE_URL, Constants.POWER);

            var response = await App.driveClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var powerList = JsonConvert.DeserializeObject<List<Power>>(json);

            powerList = powerList.Where(p => p.Status.ToLower() == "active").ToList();

            foreach(var power in powerList)
            {
                if (string.IsNullOrEmpty(power.LastLocation))
                    power.LastLocation = "Unknown";
                else
                    power.LastLocation = $"Last Location: {power.LastLocation}";
            }

            return powerList;
        }

        public static void SetPower(string unitNumber, int id)
        {
            Preferences.Set("UnitNumber", unitNumber);
            Preferences.Set("PowerId", id);
        }
    }


}
