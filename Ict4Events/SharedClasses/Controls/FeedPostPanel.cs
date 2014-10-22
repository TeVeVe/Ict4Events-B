using System.Drawing;
using System.Windows.Forms;

namespace SharedClasses.Controls
{
    internal partial class FeedPostPanel : UserControl
    {
        public FeedPostPanel()
        {
            InitializeComponent();
        }

        public string Content
        {
            get { return textBoxContent.Text; }
            set { textBoxContent.Text = value; }
        }

        public Image Image
        {
            get { return pictureBoxImage.Image; }
            set { pictureBoxImage.Image = value; }
        }
    }
}