using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMobile.Models
{
    public class StopGroup
    {
        public Location Location { get; set; }
        public string StopType { get; set; }
        public int StopTypeId { get; set; }
        public int DispatchLoadId { get; set; }
        public IList<Stop> Stops { get; set; }
        public DockInfo DockInto { get; set; }
        public TrailerInfo TrailerInfo { get; set; }
        public DateTime EstimatedStartTime { get; set; }
        public DateTime LatestStartTime { get; set; }
        public bool Completed { get; set; }

    }
}
