using System.Windows.Controls;
using System.Windows.Forms;
using SharedClasses.Extensions;
using SharedClasses.Interfaces;

namespace SharedClasses.Controls.WinForms.MVC
{
    /// <summary>
    /// Base <see cref="Form"/> for enabling a MVC architecture.
    /// </summary>
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

        /// <summary>
        ///     Currently active controller. If changed, will update UI automatically.
        /// </summary>
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

        /// <summary>
        ///     Adds a new menuitem to the menustrip.
        /// </summary>
        /// <param name="text">Text of the new menuitem.</param>
        /// <param name="controller">Object responsible for showing the new UI.</param>
        public void AddMenuItem(string text, IController controller)
        {
            var item = new ToolStripMenuItem
            {
                Text = text
            };
            item.Click += (sender, args) => ActiveController = controller;
            menuStripNavigation.Items.Add(item);
        }

        /// <summary>
        ///     Adds a new menuitem to the menustrip.
        /// </summary>
        /// <param name="item">Any type of <see cref="ToolStripItem" />.</param>
        /// <param name="controller">Object responsible for showing the new UI.</param>
        public void AddMenuItem(ToolStripItem item, IController controller)
        {
            item.Click += (sender, args) => ActiveController = controller;
            menuStripNavigation.Items.Add(item);
        }
    }
}