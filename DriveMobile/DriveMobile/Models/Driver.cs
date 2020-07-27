using DriveMobile.Helpers;
using Newtonsoft.Json;
using SQLite;
using System;
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
      
            string url = string.Format(Constants.DRIVE_BASE_URL, Constants.AUTH);
            var credsInJson = JsonConvert.SerializeObject(credentials);
            var stringContent = new StringContent(credsInJson, Encoding.UTF8, "application/json");


            var response = await App.client.PostAsync(url, stringContent);
            var json = await response.Content.ReadAsStringAsync();
            Driver driver = JsonConvert.DeserializeObject<Driver>(json);


            Preferences.Set("authToken", driver.AccessToken);
            Preferences.Set("fullName", driver.FullName);
            Preferences.Set("expiration", DateTime.Now.AddSeconds(driver.ExpiresIn));

            // setting default authToken in the global httpClient see app.xaml.cs
            App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", driver.AccessToken);

            PaySheet.GetCurrentOrNewPaysheet();

            return loggedin;
        }

        public async static void Logout()
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Switch Powers", "Are you switching powers?", "Yes", "No");

            if (answer)
            {
                Preferences.Clear();
                SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                PaySheetEntry.LeavePower();

                conn.DropTable<PaySheetEntry>();
                conn.Close();
            }
            else
            {

            }
        }

        public static void PunchOut()
        {
            Preferences.Clear();
            
        }
    }
}
