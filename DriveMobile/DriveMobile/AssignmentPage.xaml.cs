using DriveMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignmentPage : ContentPage
    {
        readonly AssignmentVM viewModel;
        public AssignmentPage()
        {
            InitializeComponent();

            viewModel = new AssignmentVM();

            BindingContext = viewModel;
        }
    }
}