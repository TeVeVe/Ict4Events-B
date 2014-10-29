using System.Windows.Forms;
using SharedClasses.Events;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace ProductRentalApplication.Controllers
{
    public class ControllerLogin : ControllerMVC<ViewLogin>
    {
        public ControllerLogin()
        {
            View.Authenticate += ViewOnAuthenticate;
        }

        private void ViewOnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            // Authenticate user.
            e.Authorized = true;

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
            else
            {
                MainForm.ActiveController = new ControllerMain();
            }
        }
    }
}