using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DriveMobile.ViewModels.Commands
{
    class SearchPowerCommand : ICommand
    {
        public PowerVM viewModel { get; set; }

        public SearchPowerCommand(PowerVM powerVM)
        {
            viewModel = powerVM;
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 0067

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SeachPower();
        }
    }
}
