using DriveMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DriveMobile.ViewModels.Commands
{
    class SelectPowerCommand : ICommand
    {
        public PowerVM ViewModel { get; set; }

        public SelectPowerCommand(PowerVM powerVM)
        {
            ViewModel = powerVM;
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 0067

        public bool CanExecute(object parameter)
        {
            var power = (Power)parameter;

            if (power == null)
                return false;
            else
                return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.SelectPower();
        }
    }
}
