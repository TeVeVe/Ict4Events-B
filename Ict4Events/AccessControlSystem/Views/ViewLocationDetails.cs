using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AccessControlSystem.Properties;
using SharedClasses.Controls.WinForms;

namespace AccessControlSystem.Views
{
    public partial class ViewLocationDetails : UserControl
    {
        private string _visitorName;

        public ViewLocationDetails()
        {
            InitializeComponent();
        }

        public InteractiveMap InteractiveMap
        {
            get { return interactiveMap1; }
        }

        public string VisitorName
        {
            get { return _visitorName; }
            set
            {
                if (_visitorName == value) return;
                _visitorName = value;
                labelMessage.Text = string.Format(Resources.ViewLocationDetails_VisitorWelcomeText, _visitorName);
            }
        }
    }
}