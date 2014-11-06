﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedClasses.Data;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace MediaSharingApplication.Controllers
{
    class ControllerRegisterAccount : ControllerMVC<ViewRegisterAccount>
    {
        public ControllerRegisterAccount()
        {
            View.RegisterClick += ViewOnRegisterClick;
        }

        private void ViewOnRegisterClick(object sender, EventArgs eventArgs)
        {
            if (!View.PasswordIsMatch)
            {
                MessageBox.Show("Het wachtwoord komt niet overeen met het tweede veld", "Wachtwoord is niet hetzelfde",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // Check if user already exists.
            var account = UserAccount.Select(string.Format("upper(USERNAME) = upper({0})", View.Username.ToSqlFormat())).FirstOrDefault();
            if (account != null)
            {
                MessageBox.Show("Deze gebruikersnaam is al in gebruik.", "Gebruikersnaam in gebruik.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            account = new UserAccount()
            {
                Username = View.Username,
                Password = View.Password,
                VisitorCode = (string)Values["VisitorCode"]
            };
            account.Insert();

            MessageBox.Show("Uw account is aangemaakt.", "Account aangemaakt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainForm.Open<ControllerMain>();
        }
    }
}
