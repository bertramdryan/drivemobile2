using DriveMobile.Models;
using DriveMobile.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace DriveMobile.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {

        public LoginCommand LoginCmd { get; set; }

        private Credentials credentials;

        public Credentials Credentials
        {
            get { return credentials; }
            set
            {
                OnPropertyChanged("Credentials");
                credentials = value;
            }
        }


        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {

                userName = value;
                Credentials = new Credentials()
                {
                    UserName = this.UserName,
                    Password = this.password,
                };

                OnPropertyChanged("UserName");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                Credentials = new Credentials()
                {
                    UserName = this.UserName,
                    Password = this.password,
                };
                OnPropertyChanged("Password");
            }
        }

        public LoginVM()
        {
            credentials = new Credentials();
            LoginCmd = new LoginCommand(this);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public async void Login()
        {
            bool loginSuccess = await Driver.Login(this.credentials);

            if (loginSuccess)
            {
                
            }

        }
    }
}
