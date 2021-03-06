using DriveMobile.Models;
using System;   
using System.Windows.Input;

namespace DriveMobile.ViewModels.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginVM ViewModel { get; set; }

        public LoginCommand(LoginVM loginVm)
        {
            ViewModel = loginVm;
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 0067

        public bool CanExecute(object parameter)
        {
            var credentials = (Credentials)parameter;

            if (credentials == null)
                return false;

            if (string.IsNullOrEmpty(credentials.UserName) || string.IsNullOrEmpty(credentials.Password))
                return false;
            else
                return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.Login();
        }
    }
}
