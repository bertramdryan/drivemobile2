using DriveMobile.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DriveMobile.Models
{
    public enum PaySheetEntryTypeEnums
    {
        PunchIn = 0,
        CompleteDunnage = 1,
        Arrive = 2,
        Depart = 3,
        BreakStart = 4,
        BreakEnd = 5,
        PunchOut = 8,
        LeavePower = 9,
        FuelStart = 10,
        FuelEnd = 11,
        BreakdownStart = 12,
        BreakdownEnd = 13,
        EnterPower = 14,
        LayoverStart = 15,
        LayoverStop = 16
    }

    public class PaySheetEntry
    {
        #region PaySheetEntry Properties
        [IgnoreDataMember]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public long PaySheetId { get; set; }
        public int EntryType { get; set; }
        public int? TrailerId { get; set; }
        public string TrailerName { get; set; }
        public int? PowerId { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime EntryCreated { get; set; }
        public int? DispatchLoadId { get; set; }
        public int? DispatchLoadStopId { get; set; }
        public int? OrderStopId { get; set; }
        public int? OtherStopId { get; set; }
        public bool IsEquipmentMove { get; set; }
        public string OtherStopName { get; set; }
        public string OtherStopAddress1 { get; set; }
        public string OtherStopAddress2 { get; set; }
        public string OtherStopCity { get; set; }
        public string OtherStopState { get; set; }
        public string OtherStopZip { get; set; }
        public int? OrderId { get; set; }
        public int? DriverId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string EstimatedZipCode { get; set; }
        public double? PiecesActual { get; set; }
        public double? Damaged { get; set; }
        public double? Pieces { get; set; }
        public double? Count { get; set; }
        public double? Mileage { get; set; }
        public bool IsHourly { get; set; }
        public bool ForAllocatedOrder { get; set; }
        [IgnoreDataMember]
        public bool SentToServer { get; set; }
        #endregion PaySheetEntry Properties

        #region Paysheet Entries
        public async static Task<bool> PunchIn()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.PunchIn);
            if (punchInEntry != null)
            {
                InsertIntoSQLite(punchInEntry);
                App.status = PaySheetEntryTypeEnums.PunchIn;
            }

            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> CompletleDunnage()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.CompleteDunnage);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.CompleteDunnage;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> Arrive(List<Stop> stops)
        {
            List<PaySheetEntry> paySheetEntries = new List<PaySheetEntry>();

            foreach (var stop in stops)
                paySheetEntries.Add(CreatePaysheetEntry(PaySheetEntryTypeEnums.Arrive, stop));

            BatchInsertIntoSQLite(paySheetEntries);
            App.status = PaySheetEntryTypeEnums.Arrive;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;

        }

        public async static Task<bool> Depart(List<Stop> stops)
        {
            List<PaySheetEntry> paySheetEntries = new List<PaySheetEntry>();

            foreach (var stop in stops)
                paySheetEntries.Add(CreatePaysheetEntry(PaySheetEntryTypeEnums.Depart, stop));

            BatchInsertIntoSQLite(paySheetEntries);
            App.status = PaySheetEntryTypeEnums.Depart;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> BreakStart()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.BreakStart);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.BreakStart;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> BreakEnd()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.BreakEnd);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.BreakEnd;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> PunchOut()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.PunchOut);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.PunchOut;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> LeavePower()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.LeavePower);
            InsertIntoSQLite(punchInEntry);
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> FuelStart()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.FuelStart);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.FuelStart;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> FuelEnd()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.FuelEnd);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.FuelEnd;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> BreakdownStart()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.BreakdownStart);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.BreakdownStart;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> BreakdownEnd()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.BreakdownEnd);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.BreakdownEnd;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> EnterPower()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.EnterPower);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.EnterPower;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }


        public async static Task<bool> LayoverStart()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.LayoverStart);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.LayoverStart;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        public async static Task<bool> LayoverStop()
        {
            PaySheetEntry punchInEntry = await CreatePaysheetEntry(PaySheetEntryTypeEnums.LayoverStop);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.LayoverStop;
            var result = await SendToServer();

            if (result)
                return true;
            else
                return false;
        }

        #endregion Paysheet Entries

        #region Sqlite Queries
        private static void BatchInsertIntoSQLite(List<PaySheetEntry> paysheetEntries)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<PaySheetEntry>();
                conn.InsertAll(paysheetEntries);
            }
        }

        private static void InsertIntoSQLite(PaySheetEntry paysheetEntry)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<PaySheetEntry>();
                conn.Insert(paysheetEntry);
            }
        }

        private static List<PaySheetEntry> GetPaySheetEntriesToPost()
        {
            List<PaySheetEntry> psToSend = new List<PaySheetEntry>();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<PaySheetEntry>();

                psToSend = conn.Table<PaySheetEntry>().Where(p => p.SentToServer == false).ToList();
            }

            return psToSend;
        }


        private static void UpdatePaySheet(PaySheetEntry updatedPaysheetEntry)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<PaySheetEntry>();

                conn.Update(updatedPaysheetEntry);
            }
        }

        #endregion Sqlite Queries

        #region Create PaysheetEntries
        private async static Task<PaySheetEntry> CreatePaysheetEntry(PaySheetEntryTypeEnums entryType)
        {
            DateTime currentTime = DateTime.UtcNow;
            PaySheetEntry paySheetEntry = new PaySheetEntry();

            int driverId = 0;
            
            if(Preferences.ContainsKey("DriverId"))
                driverId = Preferences.Get("DriverId", 0);

            int paysheetId = 0;
            int? powerId = null;

            CurrentLocation currentLocation = new CurrentLocation();

            if (entryType != PaySheetEntryTypeEnums.PunchIn)
            {
                currentLocation = await CurrentLocation.GetLocation();
            }

            if (Preferences.ContainsKey("PaysheetId"))
                paysheetId = Preferences.Get("PaysheetId", 0);

            if (Preferences.ContainsKey("PowerId"))
                powerId = Preferences.Get("PowerId", 0);

            if (powerId == 0 || paysheetId == 0 || driverId == 0)
            {
                await App.Current.MainPage.DisplayAlert(Constants.PAYSHEET_WARNING_TITLE, Constants.PAYSHEET_WARNING_MESSAGE, "Ok");
            }

            try
            {
                if (paysheetId == 0 && entryType != PaySheetEntryTypeEnums.PunchIn)
                    throw new Exception(Constants.PAYSHEET_EXCEPTION);

                else
                {
                    paySheetEntry = new PaySheetEntry()
                    {
                        PaySheetId = paysheetId,
                        EntryType = (int)entryType,
                        EntryDate = currentTime,
                        EntryCreated = currentTime,
                        DriverId = driverId,
                        Mileage = currentLocation?.Odometer,
                        Latitude = currentLocation?.Lat,
                        Longitude = currentLocation?.Lon,
                        PowerId = powerId != 0 ? powerId : null,

                    };

                    return paySheetEntry;
                }


            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("PaysheetEntry Error", ex.Message, "Ok");
            }

            return paySheetEntry;
        }


        private static PaySheetEntry CreatePaysheetEntry(PaySheetEntryTypeEnums entryType, Stop stop)
        {
            DateTime currentTime = DateTime.UtcNow;
            bool arrival = entryType == PaySheetEntryTypeEnums.Arrive;

            int driverId = 0;

            if (Preferences.ContainsKey("DriverId"))
                driverId = Preferences.Get("DriverId", 0);

            int paysheetId = 0;
            int? powerId = null;
            int? trailerId = null;

            CurrentLocation currentLocation = new CurrentLocation();

            if (Preferences.ContainsKey("PaysheetId"))
                paysheetId = Preferences.Get("PaysheetId", 0);


            if (Preferences.ContainsKey("PowerId"))
                powerId = Preferences.Get("PowerId", 0);


            if (Preferences.ContainsKey("TrailerId"))
                trailerId = Preferences.Get("TrailerId", 0);

            PaySheetEntry paySheetEntry = new PaySheetEntry()
            {
                PaySheetId = paysheetId,
                EntryType = (int)entryType,
                EntryDate = currentTime,
                EntryCreated = currentTime,
                DriverId = driverId,
                Mileage = currentLocation?.Odometer,
                Latitude = currentLocation?.Lat,
                Longitude = currentLocation?.Lon,
                PowerId = powerId != 0 ? powerId : null,
                TrailerId = trailerId
                
            };


            return paySheetEntry;
        }

        #endregion Create PaysheetEntries

        #region Send to DriveAPI
        private static async Task<bool> SendToServer()
        {
            var paysheetEntries = GetPaySheetEntriesToPost();

            if (paysheetEntries.Count > 0)
            {
                string url = string.Format(Constants.DRIVE_BASE_URL, Constants.SAVE_MULTIPLE_PAYSHEET_ENTRIES);
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var paysheetsInJson = JsonConvert.SerializeObject(paysheetEntries, jsonSerializerSettings);
                var stringContent = new StringContent(paysheetsInJson, Encoding.UTF8, "application/json");

                var result = await App.driveClient.PostAsync(url, stringContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    foreach (var paysheetEntry in paysheetEntries)
                    {
                        paysheetEntry.SentToServer = true;
                        UpdatePaySheet(paysheetEntry);
                    }

                    return true;
                }
            }

            return false;
        }
        #endregion Send to DriveAPI
    }

}

