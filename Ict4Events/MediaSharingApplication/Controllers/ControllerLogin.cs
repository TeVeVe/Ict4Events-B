using System.Diagnostics;
using System.Windows.Forms;
using SharedClasses.Data.Models;
using SharedClasses.Events;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace MediaSharingApplication.Controllers
{
    class ControllerLogin : ControllerMVC<ViewLogin>
    {
        public ControllerLogin()
        {
            View.Authenticate += ViewOnAuthenticate;
        }

        private void ViewOnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            // Authenticate user.
            var accounts = UserAccount.Select("1=1");

            foreach (var userAccount in accounts)
            {
                Debug.WriteLine(userAccount.Password);
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
                MainForm.PopupController(new ControllerRegisterAccount());
            }
            else
            {
                MainForm.ActiveController = new ControllerMain();
            }
        }
    }
}
