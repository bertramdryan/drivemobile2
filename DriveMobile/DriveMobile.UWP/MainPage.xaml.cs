using System;
using System.IO;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace DriveMobile.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1024.0, 600.0);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            
            string dbName = "paysheetentry.sqlite";
            string folderPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullPath = Path.Combine(folderPath, dbName);


            LoadApplication(new DriveMobile.App(fullPath));
        }
    }
}
