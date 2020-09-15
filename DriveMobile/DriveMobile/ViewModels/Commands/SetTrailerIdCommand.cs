using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DriveMobile.ViewModels.Commands
{
    public class SetTrailerIdCommand : ICommand
    {
        public AssignmentVM ViewModel { get; set; }

        public SetTrailerIdCommand(AssignmentVM viewModel)
        {
            ViewModel = viewModel;
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 0067

        public bool CanExecute(object parameter)
        {
            string? trailerId = (string?)parameter;

            return string.IsNullOrEmpty(trailerId);
        }

        public void Execute(object parameter)
        {
            string? trailerId = (string?)parameter;

            ViewModel.SetTrailerId(trailerId);
        }
    }
}
