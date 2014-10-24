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

        public List<InteractiveMap.Spot> Spots
        {
            get { return interactiveMap1.Spots; }
        }

        public Image ImageMap
        {
            get { return interactiveMap1.ImageMap; }
            set { interactiveMap1.ImageMap = value; }
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