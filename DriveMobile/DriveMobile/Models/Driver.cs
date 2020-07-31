using DriveMobile.Helpers;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;

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
            Driver driver = new Driver();
            string json;
            bool loggedIn = false;

            string url = string.Format(Constants.DRIVE_BASE_URL, Constants.AUTH);
            var credsInJson = JsonConvert.SerializeObject(credentials);
            var stringContent = new StringContent(credsInJson, Encoding.UTF8, "application/json");


            var response = await App.driveClient.PostAsync(url, stringContent);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                json = await response.Content.ReadAsStringAsync();
                driver = JsonConvert.DeserializeObject<Driver>(json);
                loggedIn = true;
                Preferences.Set("authToken", driver.AccessToken);
                Preferences.Set("fullName", driver.FullName);
                Preferences.Set("expiration", DateTime.Now.AddSeconds(driver.ExpiresIn));
                App.driver = driver;
                App.loggedIn = true;

                // setting default authToken in the global httpClient see app.xaml.cs
                App.driveClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", driver.AccessToken);

                bool gotPaySheet = await PaySheet.GetCurrentOrNewPaysheet();

                if (gotPaySheet)
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<PaySheetEntry>();
                        var punchIn = conn.Table<PaySheetEntry>().ToList().Where(p => p.EntryType == PaySheetEntryTypeEnums.PunchIn).ToList();
                        if (punchIn.Count == 0)
                        {
                            await PaySheetEntry.PunchIn();
                        }
                    }
                else
                    loggedIn = false;
            }

            return loggedIn;
        }

        public async static void Logout()
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Switch Powers", "Are you switching powers?", "Yes", "No");

            if (answer)
            {
                await PaySheetEntry.LeavePower();
                string url = string.Format(Constants.DRIVE_BASE_URL, Constants.LOGOUT);
                var emptyPost = JsonConvert.SerializeObject(new object());
                var stringContent = new StringContent(emptyPost, Encoding.UTF8, "application/json");

                App.driver = null;
                App.loggedIn = false;
                
                await App.driveClient.PostAsync(url, stringContent);

                await App.Current.MainPage.Navigation.PushAsync(new LoginPage());


            }

        }

        public async static void PunchOut()
        {
            await PaySheetEntry.LeavePower();
            string url = string.Format(Constants.DRIVE_BASE_URL, Constants.LOGOUT);
            var emptyPost = JsonConvert.SerializeObject(new object());
            var stringContent = new StringContent(emptyPost, Encoding.UTF8, "application/json");
            await App.driveClient.PostAsync(url, stringContent);
            Preferences.Clear();
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.DropTable<PaySheetEntry>();
            conn.Close();
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}
