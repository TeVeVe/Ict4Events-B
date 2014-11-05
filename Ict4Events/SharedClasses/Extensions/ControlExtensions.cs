using System;
using System.Windows.Forms;
using SharedClasses.Interfaces;

namespace SharedClasses.Extensions
{
    public static class ControlExtensions
    {
        public static void AssignView(this Panel container, Control view)
        {
            // Clean up everything.
            container.InvokeSafe((c) => c.Controls.Clear());

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

        public static void InvokeSafe<T>(this T control, Action<T> action) where T : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => action(control)));
            else
                action(control);
        }
    }
}