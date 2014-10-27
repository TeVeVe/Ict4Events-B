using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductRentalApplication.Views
{
    public partial class ViewMain : UserControl
    {
        public event EventHandler AddProductClick;

        protected virtual void OnAddProductClick()
        {
            EventHandler handler = AddProductClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public ViewMain()
        {
            InitializeComponent();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            OnAddProductClick();
        }
    }
}
