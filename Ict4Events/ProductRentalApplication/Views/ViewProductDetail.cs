using System;
using System.Windows.Forms;
using SharedClasses.Data.Models;

namespace ProductRentalApplication.Views
{
    public partial class ViewProductDetail : UserControl
    {
        public ViewProductDetail()
        {
            InitializeComponent();
        }

        public Product Product
        {
            get { return (Product)textBoxProductName.Tag; }
            set
            {
                textBoxProductName.Tag = value;

                if (value != null)
                    textBoxProductName.Text = value.Name;
            }
        }

        public int Amount
        {
            get { return (int)numericUpDownAmount.Value; }
            set { numericUpDownAmount.Value = value; }
        }

        public int MaxValue
        {
            get { return (int)numericUpDownAmount.Maximum; }
            set
            {
                if (value < numericUpDownAmount.Minimum || value < 0)
                    return;
                numericUpDownAmount.Maximum = value;
            }
        }

        public event EventHandler BrowseProductsClick;
        public event EventHandler ButtonOKClick;

        protected virtual void OnButtonOkClick()
        {
            EventHandler handler = ButtonOKClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler ButtonCancelClick;

        protected virtual void OnButtonCancelClick()
        {
            EventHandler handler = ButtonCancelClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual void OnBrowseProductsClick()
        {
            EventHandler handler = BrowseProductsClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void buttonBrowseProducts_Click(object sender, EventArgs e)
        {
            OnBrowseProductsClick();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            OnButtonOkClick();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnButtonCancelClick();
        }
    }
}