using DriveMobile.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DriveMobile.Models
{
    public class CurrentLocation
    {
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public double? Odometer { get; set; }

        public async static Task<CurrentLocation> GetLocation()
        {
            int vehicleId = Preferences.Get("KTVehicleId", 0);

            CurrentLocation currentLocation = new CurrentLocation();

            if (vehicleId != 0)
            {
                string url = string.Format(Constants.KEEPTRUCKIN_LOCATION, vehicleId);
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("x-api-key", Constants.KT_API_KEY);
                    var response = await client.GetAsync(url);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        currentLocation = JsonConvert.DeserializeObject<CurrentLocation>(json);
                    }
                }
            }



            return currentLocation;
        }
    }

    public class Vehicle
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string LicensePlateState { get; set; }
        public string LicensePlateNumber { get; set; }
        public object CurrentDriver { get; set; }
    }


    public class KtVehicle
    {
        public Vehicle Vehicle { get; set; }

        public async static void SetKeepTruckingId(string unitNumber)
        {
            string url = string.Format(Constants.KEEPTRUCKIN_LOOKUP_URL, unitNumber);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", Constants.KT_API_KEY);
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                KtVehicle ktVehicle = JsonConvert.DeserializeObject<KtVehicle>(json);

                Preferences.Set("KTVehicleId", value: ktVehicle.Vehicle.Id);
            }
        }
    }

}
