using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class PanelCenteredMessage : UserControl
    {
        public PanelCenteredMessage()
        {
            InitializeComponent();
        }

        public string Message
        {
            get { return labelCenteredLabel.Text; }
            set { labelCenteredLabel.Text = value; }
        }
    }
}