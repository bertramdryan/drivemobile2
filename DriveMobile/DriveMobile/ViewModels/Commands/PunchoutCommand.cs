using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DriveMobile.ViewModels.Commands
{
    class PunchoutCommand : ICommand
    {
        LogoutVM ViewModel { get; set; }

        public PunchoutCommand(LogoutVM logoutVM)
        {
            ViewModel = logoutVM;
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 0067

        public bool CanExecute(object parameter)
        {
            if (App.numOfStopsRemaining == 0)
                return true;

            return false;
        }

        public void Execute(object parameter)
        {
            ViewModel.Punchout();
        }
    }
}
