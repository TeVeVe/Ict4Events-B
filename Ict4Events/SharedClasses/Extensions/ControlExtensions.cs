using System.Windows.Forms;
using SharedClasses.Interfaces;

namespace SharedClasses.Extensions
{
    public static class ControlExtensions
    {
        public static void AssignView(this Panel container, Control view)
        {
            // Clean up everything.
            container.Controls.Clear();

            // Initialize new view.
            //view.Dock = DockStyle.Fill;
            container.Controls.Add(view);

            // Special cases.
            var form = view as Form;
            if (form != null)
            {
                form.Parent = container;
                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.Show();
            }
        }
    }
}