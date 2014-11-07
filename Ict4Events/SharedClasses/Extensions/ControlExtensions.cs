using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SharedClasses.Extensions
{
    public static class ControlExtensions
    {
        /// <summary>
        ///     Determines if the <see cref="Form" /> is fully visible on the <see cref="Screen" />.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static bool IsFullyVisible(this Form form)
        {
            return Screen.AllScreens.Any(s => s.WorkingArea.Contains(form.DesktopBounds));
        }

        /// <summary>
        ///     Moves the <see cref="Control" /> into the container <see cref="Panel" />.
        /// </summary>
        /// <param name="container">Container to host the view.</param>
        /// <param name="view">View that will get hosted by the container.</param>
        public static void AssignView(this Panel container, Control view)
        {
            // Clean up everything.
            container.InvokeSafe(c => c.Controls.Clear());

            // Initialize new view.
            //view.Dock = DockStyle.Fill;
            container.InvokeSafe(c => c.Controls.Add(view));

            // Special cases.
            container.InvokeSafe(c =>
            {
                var form = view as Form;
                if (form != null)
                {
                    form.Parent = container;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.TopLevel = false;
                    form.Show();
                }
            });
        }

        /// <summary>
        ///     Calls the <see cref="Action" /> on the <see cref="Thread" /> that owns the <see cref="Control" />.
        /// </summary>
        /// <typeparam name="T">Any type of <see cref="Control" />.</typeparam>
        /// <param name="control">Control to call <see cref="Action" /> on.</param>
        /// <param name="action">
        ///     <see cref="Action" /> that will be executed on the <see cref="Thread" /> of the
        ///     <see cref="Control" />.
        /// </param>
        public static void InvokeSafe<T>(this T control, Action<T> action) where T : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => action(control)));
            else
                action(control);
        }

        /// <summary>
        ///     Calls the action on every <see cref="Control" /> that can be casted to <see cref="T" />.
        /// </summary>
        /// <typeparam name="T">Any type of <see cref="Control" />.</typeparam>
        /// <param name="container">Container to search for controls.</param>
        /// <param name="action">Action to execute on every <see cref="Control" /> of type <see cref="T" />.</param>
        public static void InvokeAll<T>(this Control container, Action<T> action) where T : Control
        {
            if (container == null || !container.HasChildren)
                return;

            foreach (Control control in container.Controls)
            {
                control.InvokeAll(action);
                if (!(control is T))
                    continue;
                action((T)control);
            }
        }
    }
}