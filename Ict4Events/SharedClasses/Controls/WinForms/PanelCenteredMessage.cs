using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class PanelCenteredMessage : UserControl
    {
        public string Message
        {
            get { return labelCenteredLabel.Text; }
            set { labelCenteredLabel.Text = value; }
        }

        public PanelCenteredMessage()
        {
            InitializeComponent();
        }
    }
}
