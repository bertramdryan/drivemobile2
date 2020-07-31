using DriveMobile.Models;
using DriveMobile.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriveMobile.ViewModels
{
    class LogoutVM
    {
        public LogoutCommand LogoutCmd { get; set; }
        public PunchoutCommand PunchoutCmd { get; set; }

        public LogoutVM()
        {
            LogoutCmd = new LogoutCommand(this);
            PunchoutCmd = new PunchoutCommand(this);
            
        }

        public void Logout()
        {
            Driver.Logout();
        }


        public void Punchout()
        {
            Driver.PunchOut();
           
        }
    }
}
