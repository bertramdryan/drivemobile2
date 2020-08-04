using DriveMobile.Models;
using DriveMobile.ViewModels;
using SQLite;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DriveMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        LogoutVM LogoutVM;
        MainVM MainVM;

        public MainPage()
        {
            InitializeComponent();

            MainVM = new  MainVM();
            LogoutVM = new LogoutVM();

            BindingContext = MainVM;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
