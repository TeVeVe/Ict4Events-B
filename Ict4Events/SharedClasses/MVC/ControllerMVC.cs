using System;
using System.Windows.Forms;
using SharedClasses.Events;
using SharedClasses.Interfaces;

namespace SharedClasses.MVC
{
    public abstract class ControllerMVC<T> : IController<T> where T : UserControl, new()
    {
        protected ControllerMVC()
        {
            View = new T();
        }

        /// <summary>
        ///     The hosting <see cref="FormMVC" /> that displays the view.
        /// </summary>
        public FormMVC MainForm
        {
            get { return (FormMVC)View.ParentForm; }
        }

        /// <summary>
        ///     Abstracted type of the view. Required by the interface <see cref="IController" />.
        /// </summary>
        Control IController.View
        {
            get { return View; }
            set { View = (T)value; }
        }

        /// <summary>
        ///     If true, this controller is being hosted on a seperate <see cref="Form" />.
        /// </summary>
        public bool IsPopup { get; set; }

        public virtual void Create()
        {
            
        }

        /// <summary>
        ///     View that's binded by this <see cref="IController" />.
        /// </summary>
        public T View { get; set; }

        /// <summary>
        ///     Closes this controller if it's a popup. If not, reopens the main controller if one is specified, or shows a blank
        ///     page.
        /// </summary>
        public void Close()
        {
            if (IsPopup)
                MainForm.Close();
            else if (MainForm.MainController != null)
                MainForm.ActiveController = (IController)Activator.CreateInstance(MainForm.MainController);
            else
                MainForm.ActiveController = null;
        }
    }
}