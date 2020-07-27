using DriveMobile.Helpers;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace DriveMobile.Models
{
    public class PaySheet
    {
        public IList<PaySheetEntry> PaySheetEntries { get; set; }
        public int Id { get; set; }

        public async static void GetCurrentOrNewPaysheet()
        {
            string url = string.Format(Constants.DRIVE_BASE_URL, Constants.PAYSHEET);
            var response = await App.client.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();

            PaySheet paysheet = JsonConvert.DeserializeObject<PaySheet>(json);

            if (paysheet.PaySheetEntries?.Any() != true)
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<PaySheetEntry>();
                    conn.InsertAll(paysheet.PaySheetEntries);
                }
            }
            else
            {
                PaySheetEntry.PunchIn();
            }
        }
    }
}
