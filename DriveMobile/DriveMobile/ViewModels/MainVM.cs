using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DriveMobile.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion OnPropertyChanged
    }
}
