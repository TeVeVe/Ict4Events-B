using System.Drawing;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    internal partial class PanelFeedPost : UserControl
    {
        public PanelFeedPost()
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