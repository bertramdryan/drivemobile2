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

        private string stopTypeName;
        public string StopTypeName
        {
            get { return stopTypeName.Trim(); }
            set
            {
                stopTypeName = value;
                OnPropertyChanged("StopTypeName");
            }
        }


        private int stopTypeId;

        public int StopTypeId
        {
            get { return stopTypeId; }
            set
            {
                stopTypeId = value;
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

        private List<Stop> stops;

        public List<Stop> Stops
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
        public TrailerInfo TrailerInfo
        {
            get { return trailerInfo; }
            set { trailerInfo = value; }
        }

        private bool departsWithTrailer;

        public bool DepartsWithTrailer
        {
            get { return departsWithTrailer; }
            set { departsWithTrailer = value; }
        }


        private bool arrivesWithTrailer;

        public bool ArrivesWithTrailer
        {
            get { return arrivesWithTrailer; }
            set { arrivesWithTrailer = value; }
        }



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
