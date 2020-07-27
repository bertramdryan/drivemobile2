using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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

        }

        public static void PunchOut()
        {

        }
        public static void EnterPower()
        {

        }

        public static void LeavePower()
        {

        }


        public static void CompletleDunnage()
        {

        }

        public static void BreakStart()
        {

        }

        public static void BreakEnd()
        {

        }

        public static void FuelStart()
        {

        }

        public static void FuelEnd()
        {

        }

        public static void BreakdownStart()
        {

        }

        public static void BreakdownEnd()
        {

        }

        public static void LayoverStart()
        {

        }

        public static void LayoverStop()
        {

        }

        private void InsertIntoSQLite()
        {

        }

        private List<PaySheetEntry> GetPaySheetEntries()
        {
            List<PaySheetEntry> psToSend = new List<PaySheetEntry>();

            //TODO: Get paysheets from database that haven't been sent server. 

            return psToSend;
        }


        private void UpdatePaySheets(List<PaySheetEntry> updatedPaysheetEntries)
        {

        }


        private PaySheetEntry createPaysheetEntry(PaySheetEntryTypeEnums entryType)
        {
            PaySheetEntry paySheetEntry = new PaySheetEntry()
            {

            };


            return paySheetEntry;
        }
    }

}

