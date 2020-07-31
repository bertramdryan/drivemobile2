using DriveMobile.Models;
using DriveMobile.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DriveMobile.ViewModels
{
    class PowerVM : INotifyPropertyChanged
    {
        public SelectPowerCommand SelectPowerCmd { get; set; }

        public SearchPowerCommand SearchPowerCmd { get; set; }

        private List<Power> powers;

        public List<Power> Powers
        {
            get { return powers; }
            set
            {
                powers = value;
                OnPropertyChanged("Powers");
            }
        }

        private string powerSearchString;

        public string PowerSearchString
        {
            get { return powerSearchString; }
            set
            {
                powerSearchString = value;
                OnPropertyChanged("PowerSearchString");
            }
        }


        private List<Power> searchPowerList;

        public List<Power> SearchPowerList
        {
            get { return searchPowerList; }
            set
            {
                searchPowerList = value;
                OnPropertyChanged("SearchPowerList");
            }
        }


        private Power selectedPower;
        public Power SelectedPower
        {
            get { return selectedPower; }
            set
            {
                selectedPower = value;
                if (SelectedPower != null)
                {
                    PowerSearchString = SelectedPower.UnitNumber;
                }
                OnPropertyChanged("SelectedPower");
            }
        }


        public PowerVM()
        {
            PopulatePowerList();
            SelectPowerCmd = new SelectPowerCommand(this);
            SearchPowerCmd = new SearchPowerCommand(this);
        }

        #region Public Methods

        public void SeachPower()
        {
            if (string.IsNullOrEmpty(PowerSearchString))
            {
                SearchPowerList = Powers;
            }
            else
            {
                SearchPowerList = Powers.Where(p => p.UnitNumber.StartsWith(PowerSearchString)).ToList();
            }

        }

        public void SelectPower()
        {
            KtVehicle.SetKeepTruckingId(selectedPower.UnitNumber);
            Power.SetPower(selectedPower.UnitNumber, selectedPower.Id);
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
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
            SearchPowerList = Powers;
        }

        #endregion Private Methods

    }
}
