using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DriveMobile.ViewModels.Commands
{
    public class DepartCommand : ICommand
    {
#pragma warning disable 0067
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 0067

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
