using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccessControlSystem.Properties;

namespace AccessControlSystem.Views
{
    public partial class ViewLocationDetails : UserControl
    {
        private string _visitorName;

        public string VisitorName
        {
            get { return _visitorName; }
            set
            {
                if (_visitorName == value) return;
                _visitorName = value;
                label1.Text = string.Format(Resources.ViewLocationDetails_VisitorWelcomeText, _visitorName);
            }
        }

        public ViewLocationDetails()
        {
            InitializeComponent();
        }
    }
}
