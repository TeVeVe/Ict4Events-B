using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedClasses.Controls
{
    public partial class FeedPostPanel : UserControl
    {
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

        public FeedPostPanel()
        {
            InitializeComponent();

        }
    }
}
