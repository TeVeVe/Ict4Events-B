using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaSharingApplication.Views
{
    public partial class ViewFileDetail : UserControl
    {
        public event EventHandler BackButtonClick;
        public event EventHandler DownloadButtonClick;

        protected virtual void OnDownloadButtonClick()
        {
            EventHandler handler = DownloadButtonClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual void OnBackButtonClick()
        {
            EventHandler handler = BackButtonClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public ViewFileDetail()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            OnBackButtonClick();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            OnDownloadButtonClick();
        }
    }
}
