using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DriveMobile.ViewModels.Commands
{
    public class ArriveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
