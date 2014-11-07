using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MediaSharingApplication.Views;
using SharedClasses.Data.Models;
using SharedClasses.Detectors;
using SharedClasses.Events;
using SharedClasses.Extensions;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace MediaSharingApplication.Controllers
{
    class ControllerLogin : ControllerMVC<ViewLogin>
    {
        private RadioFrequency _rfidDetector;

        public ControllerLogin()
        {
            //_rfidDetector = new RadioFrequency();
            //View.Authenticate += ViewOnAuthenticate;

            //// Fill in the RFID tag automatically on scan.
            //_rfidDetector.Tag += (sender, args) => View.RFID = args.Value;
        }

        private void ViewOnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            UserAccount account = null;
            Wristband wristband = null;

            // Authenticate user.
            switch (e.AuthMethod)
            {
                case AuthenticateEventArgs.AuthenticationMethod.Account:
                    account = UserAccount.Select(string.Format("USERNAME = {0} AND PASSWORD = {1}", e.Username.ToSqlFormat(), e.Password.ToSqlFormat())).FirstOrDefault();
                    e.Authorized = account != null;
                    break;
                case AuthenticateEventArgs.AuthenticationMethod.RFIDNumber:
                    wristband = Wristband.Select(string.Format("VISITORCODE = {0}", e.RFIDNumber.ToSqlFormat())).FirstOrDefault();
                    e.Authorized = wristband != null;
                    break;
            }

            // Report back to user.
            if (!e.Authorized)
            {
                MessageBox.Show(
                    string.Format("Inloggen mislukt. Uw {0} onjuist",
                        e.AuthMethod == AuthenticateEventArgs.AuthenticationMethod.RFIDNumber
                            ? "pasnummer is"
                            : "accountgegevens zijn"), "Ongeldige authenticatie", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (e.AuthMethod == AuthenticateEventArgs.AuthenticationMethod.RFIDNumber)
            {
                // Check if the RFID number already has an account.
                var rfidAccount =
                    UserAccount.Select("VISITORCODE = " + wristband.VisitorCode.ToSqlFormat()).FirstOrDefault();
                if (rfidAccount != null)
                {
                    MessageBox.Show("Er is al een account aangemaakt voor het pasnummer.", "Account bestaat al",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MainForm.Open<ControllerRegisterAccount>(new KeyValuePair<string, object>("VisitorCode", wristband.VisitorCode));
            }
            else
            {
                ((FormMain)MainForm).UserSession = account;
                MainForm.Open<ControllerMain>();
            }
        }
    }
}
