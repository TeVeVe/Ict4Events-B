using System.Windows.Forms;

namespace SharedClasses.Extensions
{
    public static class ControlExtensions
    {
        public static void ShowInView(this Control parent, Form target)
        {
            target.Load += (sender, args) => target.Dock = DockStyle.Fill;
            target.TopLevel = false;
            target.Parent = parent;

            parent.Controls.Clear();
            parent.Controls.Add(target);
            target.FormBorderStyle = FormBorderStyle.None;
            target.Show();
        }

        public static void ShowInView(this Control parent, UserControl target)
        {
            target.Load += (sender, args) => target.Dock = DockStyle.Fill;
            
            parent.Controls.Clear();
            parent.Controls.Add(target);
        }
    }
}