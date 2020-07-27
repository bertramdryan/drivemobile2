using DriveMobile.Helpers;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
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
        [IgnoreDataMember]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public long PaySheetId { get; set; }
        public PaySheetEntryTypeEnums EntryType { get; set; }
        public long? TrailerId { get; set; }
        public string TrailerName { get; set; }
        public long? StopTypeId { get; set; }
        public string StopTypeName { get; set; }
        public long? PowerId { get; set; }
        public string PowerName { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime EntryCreated { get; set; }
        public long? DispatchLoadId { get; set; }
        public long? DispatchLoadStopId { get; set; }
        public long? OrderStopId { get; set; }
        public OrderStop OrderStop { get; set; }
        public string OtherStopType { get; set; }
        public long? OtherStopTypeId { get; set; }
        public bool IsEquipmentMove { get; set; }
        public string OtherStopName { get; set; }
        public string OtherStopAddress1 { get; set; }
        public string OtherStopAddress2 { get; set; }
        public string OtherStopCity { get; set; }
        public string OtherStopState { get; set; }
        public string OtherStopZip { get; set; }
        public long? OrderId { get; set; }
        public long? DriverId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string EstimatedZipCode { get; set; }
        public decimal? PiecesActual { get; set; }
        public decimal? CountActual { get; set; }
        public decimal? Damaged { get; set; }
        public decimal? Pieces { get; set; }
        public decimal? Count { get; set; }
        public string AuditedByName { get; set; }
        public string ConfirmedByName { get; set; }
        public string Notes { get; set; }
        public decimal? Mileage { get; set; }
        public bool IsHourly { get; set; }
        public bool ForAllocatedOrder { get; set; }
        public bool SentToServer { get; set; }

        public static void PunchIn()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.PunchIn);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.PunchIn;
            SendToServer();
        }

        public static void CompletleDunnage()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.CompleteDunnage);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.CompleteDunnage;
            SendToServer();
        }

        public static void Arrive(List<Stop> stops)
        {
            List<PaySheetEntry> paySheetEntries = new List<PaySheetEntry>();

            foreach (var stop in stops)
                paySheetEntries.Add(CreatePaysheetEntry(PaySheetEntryTypeEnums.Arrive, stop));

            BatchInsertIntoSQLite(paySheetEntries);
            App.status = PaySheetEntryTypeEnums.Arrive;
            SendToServer();

        }

        public static void Depart(List<Stop> stops)
        {
            List<PaySheetEntry> paySheetEntries = new List<PaySheetEntry>();

            foreach (var stop in stops)
                paySheetEntries.Add(CreatePaysheetEntry(PaySheetEntryTypeEnums.Depart, stop));

            BatchInsertIntoSQLite(paySheetEntries);
            App.status = PaySheetEntryTypeEnums.Depart;
            SendToServer();
        }

        public static void BreakStart()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.BreakStart);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.BreakStart;
            SendToServer();
        }

        public static void BreakEnd()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.BreakEnd);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.BreakEnd;
            SendToServer();
        }

        public static void PunchOut()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.PunchOut);
            InsertIntoSQLite(punchInEntry);
            SendToServer();
        }

        public static void LeavePower()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.LeavePower);
            InsertIntoSQLite(punchInEntry);
            SendToServer();
        }

        public static void FuelStart()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.FuelStart);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.FuelStart;
            SendToServer();
        }

        public static void FuelEnd()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.FuelEnd);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.FuelEnd;
            SendToServer();
        }

        public static void BreakdownStart()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.BreakdownStart);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.BreakdownStart;
            SendToServer();
        }

        public static void BreakdownEnd()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.BreakdownEnd);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.BreakdownEnd;
            SendToServer();
        }

        public static void EnterPower()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.EnterPower);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.EnterPower;
            SendToServer();
        }


        public static void LayoverStart()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.LayoverStart);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.LayoverStart;
            SendToServer();
        }

        public static void LayoverStop()
        {
            PaySheetEntry punchInEntry = CreatePaysheetEntry(PaySheetEntryTypeEnums.LayoverStop);
            InsertIntoSQLite(punchInEntry);
            App.status = PaySheetEntryTypeEnums.LayoverStop;
            SendToServer();
        }

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

                conn.Table<PaySheetEntry>().Where(p => p.SentToServer == false).ToList();
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


        private static PaySheetEntry CreatePaysheetEntry(PaySheetEntryTypeEnums entryType)
        {
            DateTime currentTime = DateTime.UtcNow;

            PaySheetEntry paySheetEntry = new PaySheetEntry()
            {

            };


            return paySheetEntry;
        }

        private static PaySheetEntry CreatePaysheetEntry(PaySheetEntryTypeEnums entryType, Stop stop)
        {
            DateTime currentTime = DateTime.UtcNow;
            bool arrival = entryType == PaySheetEntryTypeEnums.Arrive;

            PaySheetEntry paySheetEntry = new PaySheetEntry()
            {

            };


            return paySheetEntry;
        }

        private static async void SendToServer()
        {
            var paysheetEntries = GetPaySheetEntriesToPost();

            if (paysheetEntries != null)
            {
                string url = string.Format(Constants.DRIVE_BASE_URL, Constants.SAVE_MULTIPLE_PAYSHEET_ENTRIES);
                var paysheetsInJson = JsonConvert.SerializeObject(paysheetEntries);
                var stringContent = new StringContent(paysheetsInJson, Encoding.UTF8, "application/json");

                var result = await App.client.PostAsync(url, stringContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    foreach (var paysheetEntry in paysheetEntries)
                        paysheetEntry.SentToServer = true;

                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.UpdateAll(paysheetEntries);
                    }
                }
            }
        }
    }

}

