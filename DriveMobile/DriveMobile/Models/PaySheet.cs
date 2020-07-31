using DriveMobile.Helpers;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DriveMobile.Models
{
    public class PaySheet
    {
        public IList<PaySheetEntry> PaySheetEntries { get; set; }
        public int Id { get; set; }

        public async static Task<bool> GetCurrentOrNewPaysheet()
        {
            PaySheet paysheet = new PaySheet();
            string json;

            string url = string.Format(Constants.DRIVE_BASE_URL, Constants.PAYSHEET);
            var response = await App.driveClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                json = await response.Content.ReadAsStringAsync();
                paysheet = JsonConvert.DeserializeObject<PaySheet>(json);
                Preferences.Set("PaysheetId", paysheet.Id);

                if (paysheet.PaySheetEntries?.Any() != true)
                {
                    // Inserting directly into db, this should be done on the PaySheetEntry Model
                    // but this already has the created paysheet entries. 
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<PaySheetEntry>();
                        conn.InsertAll(paysheet.PaySheetEntries);
                    }
                }

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
