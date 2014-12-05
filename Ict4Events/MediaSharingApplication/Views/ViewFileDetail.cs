using System;
using System.Windows.Forms;

namespace MediaSharingApplication.Views
{
    public partial class ViewFileDetail : UserControl
    {
        public ViewFileDetail()
        {
            InitializeComponent();
        }

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