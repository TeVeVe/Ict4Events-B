using System.Windows.Forms;
using SharedClasses.Extensions;
using SharedClasses.Interfaces;

namespace SharedClasses.Controls.WinForms.MVC
{
    public partial class FormMVC : Form
    {
        private IController _activeController;

        public FormMVC()
        {
            InitializeComponent();

            Load += (sender, args) =>
            {
                // Hide menu if it's not in use.
                menuStripNavigation.Visible = menuStripNavigation.Items.Count > 0;
            };
        }

        public IController ActiveController
        {
            get { return _activeController; }
            set
            {
                if (_activeController == value) return;
                _activeController = value;
                panelContent.AssignView(value.View);
            }
        }

        public void AddMenuItem(string text, IController controller)
        {
            var item = new ToolStripMenuItem() { Text = text };
            item.Click += (sender, args) => ActiveController = controller;
            menuStripNavigation.Items.Add(item);
        }

        public void AddMenuItem(ToolStripItem item, IController controller)
        {
            item.Click += (sender, args) => ActiveController = controller;
            menuStripNavigation.Items.Add(item);
        }
    }
}