using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class PanelTile : UserControl
    {
        public PanelTile(string primaryText, string secondaryText)
        {
            InitializeComponent();

            lblFileName.Text = primaryText;
            lblDescription.Text = secondaryText;
        }
    }
}
