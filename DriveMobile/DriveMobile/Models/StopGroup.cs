using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DriveMobile.Models
{
    public class StopGroup : INotifyPropertyChanged
    {
        private Location location;
        public Location Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        private string stopType;
        public string StopType
        {
            get { return stopType; }
            set
            {
                stopType = value;
                OnPropertyChanged("StopType");
            }
        }


        private int stopTypeId;

        public int StopTypeId
        {
            get { return StopTypeId; }
            set
            {
                StopTypeId = value;
                OnPropertyChanged("StopTypeId");
            }
        }

        private int dispatchLoadId;

        public int DispatchLoadId
        {
            get { return dispatchLoadId; }
            set
            {
                dispatchLoadId = value;
                OnPropertyChanged("DispatchLoadId");
            }
        }

        private IList<Stop> stops;

        public IList<Stop> Stops
        {
            get { return stops; }
            set
            {
                stops = value;
                OnPropertyChanged("Stops");
            }
        }

        private DockInfo dockInfo;

        public DockInfo DockInfo
        {
            get { return dockInfo; }
            set { dockInfo = value; }
        }

        private TrailerInfo trailerInfo;
        public TrailerInfo TrailerInfo { get; set; }
        public DateTime EstimatedStartTime { get; set; }
        public DateTime LatestStartTime { get; set; }
        public bool Completed { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
