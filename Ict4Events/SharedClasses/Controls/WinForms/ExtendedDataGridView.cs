using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class ExtendedDataGridView : DataGridView
    {
        public ExtendedDataGridView()
        {
            InitializeComponent();
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            EditMode = DataGridViewEditMode.EditProgrammatically;
            AllowUserToResizeColumns = true;
            AllowUserToResizeRows = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
