using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using AccessControlSystem.Properties;
using Spot = SharedClasses.Controls.WPF.Spot;
using UserControl = System.Windows.Forms.UserControl;

namespace AccessControlSystem.Views
{
    public partial class ViewLocationDetails : UserControl
    {
        private string _visitorName;

        // TODO: Fix WPF control in WinForms
        //public ObservableCollection<Spot> Spots
        //{
        //    get { return interactiveMap1.Spots; }
        //}

        //public ImageSource MapImage
        //{
        //    get { return interactiveMap1.MapImage; }
        //    set { interactiveMap1.MapImage = value; }
        //}

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

        public ViewLocationDetails()
        {
            InitializeComponent();
        }
    }
}
