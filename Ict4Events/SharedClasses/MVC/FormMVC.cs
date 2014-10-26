using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SharedClasses.Extensions;
using SharedClasses.Interfaces;

namespace SharedClasses.MVC
{
    /// <summary>
    ///     Base <see cref="Form" /> for enabling a MVC architecture.
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

                // Select the menuitem that has the ActiveController.
                var selectedItem =
                    menuStripNavigation.Items.Cast<ToolStripMenuItem>()
                        .FirstOrDefault(i => ((IController)i.Tag) == _activeController);

                // Deselect everything.
                foreach (ToolStripMenuItem item in menuStripNavigation.Items)
                {
                    item.BackColor = Color.FromKnownColor(KnownColor.Control);
                }

                // Mark is selected.
                if (selectedItem != null)
                    selectedItem.BackColor = Color.FromName("Cornflowerblue");

                ResetController();
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
                Text = text,
                Tag = controller
            };
            item.Click += (sender, args) => ActiveController = controller;
            menuStripNavigation.Items.Add(item);
        }

        /// <summary>
        ///     Adds a new menuitem to the menustrip where the Tag is set to the controller.
        /// </summary>
        /// <param name="item">Any type of <see cref="ToolStripItem" />.</param>
        /// <param name="controller">Object responsible for showing the new UI.</param>
        public void AddMenuItem(ToolStripItem item, IController controller)
        {
            item.Tag = controller;
            item.Click += (sender, args) => ActiveController = controller;
            menuStripNavigation.Items.Add(item);
        }

        /// <summary>
        ///     Reinitializes the controller and view. Call this when the UI is out of sync.
        /// </summary>
        public void ResetController()
        {
            if (_activeController == null) return;
            panelContent.AssignView(_activeController.View);

            // Resize form to content.
            ClientSize = new Size(_activeController.View.Width,
                _activeController.View.Height + (menuStripNavigation.Visible ? menuStripNavigation.Height : 0));

            // Reposition screen.
            CenterToScreen();
        }
    }
}