using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMobile.Models
{
    public class Manifest
    {
        public int DriverId { get; set; }
        public object PowerId { get; set; }
        public int DivisionId { get; set; }
        public int Status { get; set; }
        public DateTime EstimatedStartTime { get; set; }
        public bool IsRouteComplete { get; set; }
        public bool IsBeingDetained { get; set; }
        public int LoadTypeId { get; set; }
        public int PadCount { get; set; }
        public int StrapCount { get; set; }
        public int BarCount { get; set; }
        public int DeckingCount { get; set; }
        public bool NeedsBlocking { get; set; }
        public object CarrierCustomerId { get; set; }
        public object CarrierLocationId { get; set; }
        public object CarrierContactId { get; set; }
        public object TrailerNumber { get; set; }
        public object OnRoadOn { get; set; }
        public object OnRoadBy { get; set; }
        public object OnRoadByName { get; set; }
        public object CompletedOn { get; set; }
        public object CompletedBy { get; set; }
        public object CompletedByName { get; set; }
        public object ConfirmedByName { get; set; }
        public IList<Stop> Stops { get; set; }
        public IList<PaySheetEntry> PaySheetEntries { get; set; }
        public PaySheetEntry DunnagePaySheetEntry { get; set; }
        public int Id { get; set; }
    }

 


}
