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
    public partial class PowerPage : ContentPage
    {
        PowerVM viewModel;
        public PowerPage()
        {
            InitializeComponent();

            viewModel = new PowerVM();

            BindingContext = viewModel;
        }
    }
}