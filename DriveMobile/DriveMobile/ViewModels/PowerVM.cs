using DriveMobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DriveMobile.ViewModels
{
    class PowerVM : INotifyPropertyChanged
    {
        public List<Power> Powers { get; set; }

        private Power selectedPower;

        public Power SelectedPower
        {
            get { return selectedPower; }
            set
            {
                selectedPower = value;
                OnPropertyChanged("SelectedPower");
            }
        }


        public PowerVM()
        {
            PopulatePowerList();
        }

        #region Public Methods
        public void SelectPower()
        {

        }
        #endregion Public Methods

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion OnPropertyChanged

        #region Private Methods
        private async void PopulatePowerList()
        {
            Powers = await Power.GetPowerUnitNumbers();
        }

        #endregion Private Methods

    }
}
