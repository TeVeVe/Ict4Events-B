using System;
using System.Windows.Forms;

namespace ProductRentalApplication.Views
{
    public partial class ViewMain : UserControl
    {
        public ViewMain()
        {
            InitializeComponent();
        }

        public event EventHandler AddProductClick;

        protected virtual void OnAddProductClick()
        {
            EventHandler handler = AddProductClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            OnAddProductClick();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}