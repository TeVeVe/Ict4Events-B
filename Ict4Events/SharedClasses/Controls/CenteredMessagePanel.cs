using System.Windows.Forms;

namespace SharedClasses.Controls
{
    public partial class CenteredMessagePanel : UserControl
    {
        public string Message
        {
            get { return labelCenteredLabel.Text; }
            set { labelCenteredLabel.Text = value; }
        }

        public CenteredMessagePanel()
        {
            InitializeComponent();
        }
    }
}
