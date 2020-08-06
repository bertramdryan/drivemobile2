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
    public partial class ManifestPage : ContentPage
    {
        ManifestVM ManifestVM;
        public ManifestPage()
        {
            InitializeComponent();

            ManifestVM = new ManifestVM();

            BindingContext = ManifestVM;
        }
    }
}