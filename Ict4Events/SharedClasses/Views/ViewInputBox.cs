using System.Windows.Forms;

namespace SharedClasses.Views
{
    public partial class ViewInputBox : UserControl
    {
        public ViewInputBox()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    buttonSave.PerformClick();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}