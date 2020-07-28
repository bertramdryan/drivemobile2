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
        public event EventHandler CanExecuteChanged;

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
            throw new NotImplementedException();
        }
    }
}
