using DriveMobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DriveMobile.ViewModels
{
    class AssignmentVM : INotifyPropertyChanged
    {
        public ArriveCommand ArriveCmd { get; set; }

        private Manifest manifest;

        public Manifest Manifest
        {
            get { return manifest; }
            set
            {
                manifest = value;
                OnPropertyChanged("Manifest");
            }
        }

        private List<StopGroup> stopGroups;

        public List<StopGroup> StopGroups
        {
            get { return stopGroups; }
            set
            {
                stopGroups = value;
                OnPropertyChanged("StopGroups");
            }
        }

        public AssignmentVM()
        {

        }


        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion OnPropertyChanged
    }
}
