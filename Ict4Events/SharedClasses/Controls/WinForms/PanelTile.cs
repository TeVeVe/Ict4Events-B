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