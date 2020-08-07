using DriveMobile.Models;
using DriveMobile.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DriveMobile.ViewModels
{
    class AssignmentVM : INotifyPropertyChanged
    {
        public ArriveCommand ArriveCmd { get; set; }
        public DepartCommand DepartCmd { get; set; }
        public LayoverCommand LayoverCmd { get; set; }
        public FuelCommand FuelCmd { get; set; }
        public BreakCommand BreakCmd { get; set; }
        public BreakDownCommand BreakdownCmd { get; set; }


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
            ArriveCmd = new ArriveCommand();
            DepartCmd = new DepartCommand();
            LayoverCmd = new LayoverCommand();
            FuelCmd = new FuelCommand();
            BreakCmd = new BreakCommand();
            BreakdownCmd = new BreakDownCommand();

            GetManifestAndStopGroups();

        }

        private async void GetManifestAndStopGroups()
        {
            Manifest = await Manifest.GetManifest();
            StopGroups = Manifest.CreateStopGroups(Manifest);
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
