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
            ShowCellToolTips = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}