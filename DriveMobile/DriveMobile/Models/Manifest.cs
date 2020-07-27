using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMobile.Models
{
    public class Stop
    {
        public int? OrderStopId { get; set; }
        public object EquipmentMoveId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public int DispatchLoadId { get; set; }
        public int StopSortOrder { get; set; }
        public double Hours { get; set; }
        public double Miles { get; set; }
        public double PalletCountOnArrival { get; set; }
        public bool IsCrossDocked { get; set; }
        public DateTime EarliestArrival { get; set; }
        public DateTime LatestArrival { get; set; }
        public int StopTypeId { get; set; }
        public DateTime ActualArrivalTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public string LocationName { get; set; }
        public string StreetAddress1 { get; set; }
        public object StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string LocationPhone { get; set; }
        public int Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string StopTypeName { get; set; }
        public bool StopTypeIncrementsCount { get; set; }
        public bool HasTrailerOnArrival { get; set; }
        public bool HasTrailerOnDeparture { get; set; }
        public object TrailerId { get; set; }
        public object TrailerName { get; set; }
        public string Instructions { get; set; }
        public string DockName { get; set; }
        public string DockNotes { get; set; }
        public string DockPhone { get; set; }
        public string DockEmail { get; set; }
        public double Pieces { get; set; }
        public double Count { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public bool? Stackable { get; set; }
        public IList<OrderNote> OrderNotes { get; set; }
        public IList<object> ReferenceNumbers { get; set; }
        public int Id { get; set; }
    }

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
