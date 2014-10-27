using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SharedClasses.Exceptions;
using SharedClasses.Extensions;
using SharedClasses.Interfaces;

namespace SharedClasses.MVC
{
    /// <summary>
    ///     Base <see cref="Form" /> for enabling a MVC architecture.
    /// </summary>
    public partial class FormMVC : Form
    {
        /// <summary>
        ///     Color that will indicate that a <see cref="ToolStripMenuItem" /> is currently active.
        /// </summary>
        public static readonly Color ActiveColor = Color.FromName("Cornflowerblue");

        private IController _activeController;


        public FormMVC()
        {
            InitializeComponent();

            AllowUserResize = false;

            Load += (sender, args) =>
            {
                // Hide menu if it's not in use.
                menuStripNavigation.Visible = menuStripNavigation.Items.Count > 0;

                // Show main controller if nothing specified.
                if (MainController != null)
                {
                    // Check if a menu item has the controller. Then select it.
                    var item =
                        menuStripNavigation.Items.Cast<ToolStripMenuItem>().FirstOrDefault(i => i.Tag.GetType() == MainController);

                    if (item != null)
                        ActiveController = (IController)item.Tag;
                    else
                        ActiveController = (IController)Activator.CreateInstance(MainController);
                }
            };
        }

        /// <summary>
        ///     Fallback controller.
        /// </summary>
        public Type MainController { get; protected set; }

        /// <summary>
        ///     If true, allows users to resize the form. Uses the <see cref="Form.AutoSizeMode" /> property.
        /// </summary>
        public bool AllowUserResize
        {
            get { return AutoSizeMode == AutoSizeMode.GrowOnly; }
            set { AutoSizeMode = value ? AutoSizeMode.GrowOnly : AutoSizeMode.GrowAndShrink; }
        }

        /// <summary>
        ///     Gets or sets the currently active controller. If changed, will update UI automatically.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IController ActiveController
        {
            get { return _activeController; }
            set
            {
                if (_activeController == value) return;
                _activeController = value;

                if (_activeController != null)
                {
                    // Select the menuitem that has the ActiveController.
                    ToolStripMenuItem selectedItem =
                        menuStripNavigation.Items.Cast<ToolStripMenuItem>()
                            .FirstOrDefault(i =>
                            {
                                var tag = i.Tag;
                                if (tag != null)
                                    return tag.Equals(_activeController);
                                return false;
                            });

                    // Deselect everything.
                    foreach (ToolStripMenuItem item in menuStripNavigation.Items)
                        item.BackColor = Color.FromKnownColor(KnownColor.Control);

                    // Mark selected item.
                    if (selectedItem != null)
                        selectedItem.BackColor = ActiveColor;

                    // Init the controller on the screen (first "reset").
                    ResetController();
                }
                else
                {
                    // Deselect everything.
                    foreach (ToolStripMenuItem item in menuStripNavigation.Items)
                        item.BackColor = Color.FromKnownColor(KnownColor.Control);

                    // Show a blank page.
                    panelContent.Controls.Clear();
                }
            }
        }

        /// <summary>
        ///     Sets or gets the <seealso cref="ActiveController" /> based on the <see cref="ToolStripMenuItem.Text" />'s in the
        ///     menu.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ActiveMenuItemText
        {
            get
            {
                ToolStripMenuItem toolStripMenuItem = menuStripNavigation.Items.Cast<ToolStripMenuItem>()
                    .FirstOrDefault(i => i.BackColor == ActiveColor);
                if (toolStripMenuItem != null)
                {
                    return
                        toolStripMenuItem
                            .Text;
                }
                throw new NoActiveControllerException();
            }
            set
            {
                ToolStripMenuItem toolStripMenuItem =
                    menuStripNavigation.Items.Cast<ToolStripMenuItem>().FirstOrDefault(i => i.Text == value);
                if (toolStripMenuItem != null)
                {
                    ActiveController =
                        (IController)toolStripMenuItem.Tag;
                }
                else
                    throw new NoActiveControllerException(value);
            }
        }

        /// <summary>
        ///     Marks a controller as the fallback controller.
        /// </summary>
        /// <typeparam name="T">Any type of IController that has an empty contructor.</typeparam>
        public void MarkAsMain<T>() where T : IController, new()
        {
            MainController = typeof(T);
        }

        /// <summary>
        ///     Creates a new window for the controller and displays it.
        /// </summary>
        /// <typeparam name="T">A type of controller for displaying.</typeparam>
        /// <param name="controller">A controller to display.</param>
        /// <returns></returns>
        public T PopupController<T>(T controller) where T : class, IController
        {
            // Create a new temporary host.
            var host = new FormMVC();

            // Mark controller as popup.
            controller.IsPopup = true;
            host.ActiveController = controller;

            // Show and block code.
            host.ShowDialog();

            return controller;
        }

        /// <summary>
        ///     Adds a new menuitem to the menustrip.
        /// </summary>
        /// <param name="text">Text of the new menuitem.</param>
        /// <param name="controller">Object responsible for showing the new UI.</param>
        public ToolStripMenuItem AddMenuItem(string text, IController controller)
        {
            var item = new ToolStripMenuItem
            {
                Text = text,
                Tag = controller
            };
            item.Click += (sender, args) => ActiveController = controller;
            menuStripNavigation.Items.Add(item);
            return item;
        }

        /// <summary>
        ///     Adds a new menuitem to the menustrip where the Tag is set to the controller.
        /// </summary>
        /// <param name="item">Any type of <see cref="ToolStripItem" />.</param>
        /// <param name="controller">Object responsible for showing the new UI.</param>
        public ToolStripMenuItem AddMenuItem(ToolStripMenuItem item, IController controller)
        {
            item.Tag = controller;
            item.Click += (sender, args) => ActiveController = controller;
            menuStripNavigation.Items.Add(item);
            return item;
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

        /// <summary>
        ///     Returns the controller that has been stored by the <see cref="ToolStripMenuItem.Tag" />.
        /// </summary>
        /// <param name="menuItemName">Text of a <see cref="ToolStripMenuItem" /> to search for.</param>
        /// <returns>A controller that has been matched, or null.</returns>
        public IController GetController(string menuItemName)
        {
            ToolStripMenuItem toolStripMenuItem =
                menuStripNavigation.Items.Cast<ToolStripMenuItem>().FirstOrDefault(i => i.Text == menuItemName);
            if (toolStripMenuItem != null)
                return toolStripMenuItem.Tag as IController;
            return null;
        }
    }
}