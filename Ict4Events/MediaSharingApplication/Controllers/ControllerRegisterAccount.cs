using System;
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
            var account = UserAccount.Select("VISITORCODE = :parmVisitorCode", 0, new KeyValuePair<string, string>(":parmVisitorCode", View.Username)).FirstOrDefault();
            Debug.WriteLine(account != null);
        }
    }
}
