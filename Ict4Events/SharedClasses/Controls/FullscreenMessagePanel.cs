using System.Windows.Forms;

namespace SharedClasses.Controls
{
    public partial class FullscreenMessagePanel : UserControl
    {
        public string Message
        {
            get { return labelCenteredLabel.Text; }
            set { labelCenteredLabel.Text = value; }
        }

        public FullscreenMessagePanel()
        {
            InitializeComponent();
        }
    }
}
