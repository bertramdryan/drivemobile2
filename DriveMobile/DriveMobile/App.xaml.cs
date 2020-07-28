﻿using DriveMobile.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DriveMobile
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static Driver driver = new Driver();
        public static bool loggedIn = false;
        public static HttpClient driveClient = new HttpClient();
        public static PaySheetEntryTypeEnums status;

        public App()
        {
            InitializeComponent();

            TryAutoLogin();

            MainPage = loggedIn ? new NavigationPage(new MainPage()) : new NavigationPage(new LoginPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            TryAutoLogin();

            MainPage = loggedIn ? new NavigationPage(new MainPage()) : new NavigationPage(new LoginPage());

            DatabaseLocation = databaseLocation;

        }

        private void TryAutoLogin()
        {
            Preferences.Clear();
            if (Preferences.ContainsKey("expiration"))
            {
                DateTime expires = Preferences.Get("expiration", DateTime.Now);

                if (DateTime.Now < expires)
                {
                    loggedIn = true;

                    string authToken = Preferences.Get("authToken", string.Empty);

                    // Setting authToken to global http client. 
                    if (!string.IsNullOrEmpty(authToken))
                        driveClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                }
                else
                {
                    Preferences.Clear();
                }
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
