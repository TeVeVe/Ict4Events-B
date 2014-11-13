using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SharedClasses.Events;
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

        private readonly Dictionary<Type, IController> _controllerCache;

        private IController _activeController;

        public FormMVC()
        {
            InitializeComponent();
            _controllerCache = new Dictionary<Type, IController>();

            AllowUserResize = false;
            AlwaysOneMenuItemSelected = true;

            Load += (sender, args) =>
            {
                // Hide menu if it's not in use.
                menuStripNavigation.Visible = menuStripNavigation.Items.Count > 0;

                // Show main controller if nothing specified.
                if (ActiveController == null && MainController != null)
                {
                    // Creates a new controller if it doesn't exist already.
                    Open(MainController);
                }
            };
        }

        public bool AlwaysOneMenuItemSelected { get; set; }

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
            set
            {
                AutoSizeMode = value ? AutoSizeMode.GrowOnly : AutoSizeMode.GrowAndShrink;
                FormBorderStyle = value ? FormBorderStyle.Sizable : FormBorderStyle.FixedToolWindow;
                ResetController();
            }
        }

        /// <summary>
        ///     Gets or sets the currently active controller. If changed, will update UI automatically.
        ///     Does not reuse existing controllers.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IController ActiveController
        {
            get { return _activeController; }
            set
            {
                if (_activeController == value)
                    return;
                _activeController = value;


                if (_activeController != null)
                {
                    // Select active controller in menu.
                    MenuSelect();

                    // Init the controller on the screen (first "reset").
                    ResetController();
                }
                else
                {
                    // Deselect every menu item.
                    MenuSelect(SelectionMode.None);

                    // Show a blank page.
                    panelContent.Controls.Clear();
                }

                // Refresh user code in controller.
                _activeController.View.InvokeSafe((c) =>
                {
                    if (c != null)
                    {
                        _activeController.View.Focus();
                        _activeController.Activate();
                    }
                });
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
        ///     Iterates the menu using the <see cref="SelectionMode" />.
        /// </summary>
        /// <param name="mode"><see cref="SelectionMode" /> to use on the menu.</param>
        public void MenuSelect(SelectionMode mode = SelectionMode.One)
        {
            switch (mode)
            {
                case SelectionMode.None:
                    // Deselect everything.
                    menuStripNavigation.InvokeSafe(c =>
                    {
                        foreach (ToolStripMenuItem item in menuStripNavigation.Items)
                            item.BackColor = Color.FromKnownColor(KnownColor.Control);
                    });
                    break;
                default:
                    // Select the menuitem that has the ActiveController.
                    ToolStripMenuItem selectedItem =
                        menuStripNavigation.Items.Cast<ToolStripMenuItem>()
                            .FirstOrDefault(i =>
                            {
                                object tag = i.Tag;
                                if (tag != null)
                                    return tag.Equals(_activeController.GetType());
                                return false;
                            });


                    if (AlwaysOneMenuItemSelected && selectedItem == null)
                    {
                        // Do nothing, keep current item selected.
                        break;
                    }

                    // Deselect everything.
                    menuStripNavigation.InvokeSafe(c =>
                    {
                        foreach (ToolStripMenuItem item in menuStripNavigation.Items)
                            item.BackColor = Color.FromKnownColor(KnownColor.Control);
                    });

                    // Mark selected item.
                    menuStripNavigation.InvokeSafe(c =>
                    {
                        foreach (ToolStripMenuItem item in menuStripNavigation.Items)
                        {
                            if (item != selectedItem)
                                item.BackColor = Color.FromKnownColor(KnownColor.Control);
                            else
                                item.BackColor = ActiveColor;
                        }
                    });
                    break;
            }
        }

        public event EventHandler<ViewClosingEventArgs> ViewClosing;

        protected virtual void OnViewClosing(ViewClosingEventArgs e)
        {
            EventHandler<ViewClosingEventArgs> handler = ViewClosing;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Opens the new controller and creates it if it doesn't exist.
        /// </summary>
        /// <typeparam name="T">Any <see cref="Type" /> of <see cref="IController" />.</typeparam>
        public IController Open<T>(params KeyValuePair<string, object>[] values) where T : IController, new()
        {
            return Open(typeof(T), values);
        }

        internal IController Open(Type type, params KeyValuePair<string, object>[] values)
        {
            // Controller must be of the right type.
            if (!typeof(IController).IsAssignableFrom(type))
            {
                throw new TypeLoadException(string.Format("Type '{0}' cannot be casted to '{1}'.", type.FullName,
                    typeof(IController).FullName));
            }

            // Create controller if it doesn't exist.
            if (!_controllerCache.ContainsKey(type))
                _controllerCache.Add(type, (IController)Activator.CreateInstance(type));

            IController controller = _controllerCache[type];

            // Add or update the values of the controller.
            if (values != null)
            {
                foreach (var keyValuePair in values)
                {
                    if (controller.Values.ContainsKey(keyValuePair.Key))
                        controller.Values[keyValuePair.Key] = keyValuePair.Value;
                    else
                        controller.Values.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            // Move controller into view and mark it as active.
            ActiveController = controller;

            return controller;
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
        public T PopupController<T>() where T : IController, new()
        {
            // Activate a new temporary host.
            var host = new FormMVC();

            // Mark controller as popup.
            var controller = Open<T>();
            controller.IsPopup = true;
            host.ActiveController = controller;

            // Show and block code.
            host.ShowDialog();

            return (T)controller;
        }

        /// <summary>
        ///     Adds a new menuitem to the menustrip.
        /// </summary>
        /// <typeparam name="T">Any <see cref="Type" /> of <see cref="IController" />.</typeparam>
        /// <param name="text">Text of the new menuitem.</param>
        /// <returns>A new <see cref="ToolStripMenuItem" />.</returns>
        public ToolStripMenuItem AddMenuItem<T>(string text) where T : IController, new()
        {
            var item = new ToolStripMenuItem
            {
                Text = text,
                Tag = typeof(T)
            };
            item.Click += (sender, args) => Open<T>();
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
            if (_activeController == null)
                return;
            panelContent.AssignView(_activeController.View);

            if (!AllowUserResize)
            {
                // Resize form to content.
                _activeController.View.Dock = DockStyle.None;
                this.InvokeSafe(c => ClientSize = new Size(_activeController.View.Width,
                    _activeController.View.Height + (menuStripNavigation.Visible ? menuStripNavigation.Height : 0)));
            }
            else
                _activeController.View.Dock = DockStyle.Fill;

            _activeController.Activate();
        }

        /// <summary>
        ///     Returns the controller that has been stored by the <see cref="ToolStripMenuItem.Tag" />.
        /// </summary>
        /// <param name="menuItemName" Text of a
        /// <see cref="ToolStripMenuItem" />
        /// to search for.
        /// </param>
        /// <returns>A controller that has been matched, or null.</returns>
        public IController GetController(string menuItemName)
        {
            ToolStripMenuItem toolStripMenuItem =
                menuStripNavigation.Items.Cast<ToolStripMenuItem>().FirstOrDefault(i => i.Text == menuItemName);
            if (toolStripMenuItem != null)
                return toolStripMenuItem.Tag as IController;
            return null;
        }

        /// <summary>
        ///     Processes every key input on the form.
        /// </summary>
        /// <param name="msg">Windows message received.</param>
        /// <param name="keyData">Key information that was received from input.</param>
        /// <returns>If true, captures the keypress and doesn't send it further.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Shift | Keys.Escape:
                    Close();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}