using DriveMobile.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DriveMobile.Models
{
    public class Credentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Driver
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Timezone { get; set; }
        public int DivisionId { get; set; }
        public object DispatchTeamId { get; set; }
        public int LocationAssignmentId { get; set; }
        public int DriverId { get; set; }
        public string FullName { get; set; }


        public async static Task<bool> Login(Credentials credentials)
        {
            bool loggedin = false;
            Driver driver = new Driver();

            string url = string.Format(Constants.DRIVE_BASE_URL, Constants.AUTH);
            var credsInJson = JsonConvert.SerializeObject(credentials);
            var stringContent = new StringContent(credsInJson, Encoding.UTF8, "application/json");
            

            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(url, stringContent);
                var json = await response.Content.ReadAsStringAsync();
                driver = JsonConvert.DeserializeObject<Driver>(json);
            }



            Preferences.Set("authToken", driver.AccessToken);
            Preferences.Set("fullName", driver.FullName);
            Preferences.Set("expiration", DateTime.Now.AddSeconds(driver.ExpiresIn));

            return loggedin;
        }
    }
}
