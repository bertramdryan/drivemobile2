using DriveMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DriveMobile.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        ObservableCollection<Manifest> Manifests { get; set; }

        public MainVM()
        {
            Manifests = new ObservableCollection<Manifest>();
            GetManifests();
        }

        private async void GetManifests()
        {
            var tempManifests = await Manifest.GetManifests();
            foreach(var manifest in tempManifests)
            {
                Manifests.Add(manifest);
            }
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
