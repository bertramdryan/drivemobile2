using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMobile.Models
{
    public class Stop
    {

        public int? OrderStopId { get; set; }
        public int? EquipmentMoveId { get; set; }
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
        public string StreetAddress2 { get; set; }
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
        public int? TrailerId { get; set; }
        public string TrailerName { get; set; }
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
        public IList<ReferenceNumber> ReferenceNumbers { get; set; }
        public int Id { get; set; }
    }
}
