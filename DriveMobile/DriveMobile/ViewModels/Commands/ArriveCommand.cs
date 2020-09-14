using DriveMobile.Models;
using System;
using System.Windows.Input;

namespace DriveMobile.ViewModels.Commands
{
    public class ArriveCommand : ICommand
    {
        public AssignmentVM ViewModel { get; set; }

        public ArriveCommand(AssignmentVM viewModel)
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
            ViewModel.Arrive(stopGroup);
        }
    }
}
