using DriveMobile.Models;
using DriveMobile.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace DriveMobile.ViewModels
{
    public class AssignmentVM : INotifyPropertyChanged
    {
        public ArriveCommand ArriveCmd { get; set; }
        public DepartCommand DepartCmd { get; set; }
        public SetTrailerIdCommand SetTrailerCmd { get; set; }
        //public LayoverCommand LayoverCmd { get; set; }
        //public FuelCommand FuelCmd { get; set; }
        //public BreakCommand BreakCmd { get; set; }
        //public BreakDownCommand BreakdownCmd { get; set; }


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

        private string? trailerId;

        public string? TrailerId
        {
            get { return trailerId; }
            set
            {
                trailerId = value;
                OnPropertyChanged("TrailerId");
            }
        }


        public AssignmentVM()
        {
            ArriveCmd = new ArriveCommand(this);
            DepartCmd = new DepartCommand(this);
            SetTrailerCmd = new SetTrailerIdCommand(this);
            //LayoverCmd = new LayoverCommand();
            //FuelCmd = new FuelCommand();
            //BreakCmd = new BreakCommand();
            //BreakdownCmd = new BreakDownCommand();

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

        #region Public Command Methods
        public async void Arrive(StopGroup stopGroup)
        {
            await PaySheetEntry.Arrive(stopGroup.Stops);
        }

        public async void Depart(StopGroup stopGroup)
        {
            await PaySheetEntry.Depart(stopGroup.Stops);
            if (!stopGroup.DepartsWithTrailer && Preferences.ContainsKey("TrailerId"))
            {
                Preferences.Remove("TrailerId");
            }
        }

        public void SetTrailerId(string trailerId)
        {
            int trailerIdInt;
 
            if (int.TryParse(trailerId, out trailerIdInt))
                Preferences.Set("TrailerId", trailerId);
                TrailerId = trailerId;
        }
        #endregion Public Command Methods
    }
}
