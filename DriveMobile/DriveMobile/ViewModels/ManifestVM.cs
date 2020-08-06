using DriveMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DriveMobile.ViewModels
{
    public class ManifestVM : INotifyPropertyChanged
    {
        private ObservableCollection<Manifest> manifests;

        public ObservableCollection<Manifest> Manifests
        {
            get { return manifests; }
            set
            {
                manifests = value;
                OnPropertyChanged("Manifests");
            }
        }


        public ManifestVM()
        {
            Manifests = new ObservableCollection<Manifest>();
            GetManifests();
        }

        private async void GetManifests()
        {
            var tempManifests = await Manifest.GetManifests();
            foreach (var manifest in tempManifests)
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
