using DriveMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DriveMobile.ViewModels.Commands
{
    public class DepartCommand : ICommand
    {
        public AssignmentVM ViewModel { get; set; }
        public DepartCommand(AssignmentVM viewModel)
        {
            ViewModel = viewModel;
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
            StopGroup stopGroup = (StopGroup)parameter;
            ViewModel.Depart(stopGroup);
        }
    }
}
