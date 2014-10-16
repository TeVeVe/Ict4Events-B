using System.Windows.Forms;

namespace SharedClasses.Extensions
{
    public static class ControlExtensions
    {
        public static void ShowInView(this Control parent, UserControl target)
        {
            target.Load += (sender, args) => target.Dock = DockStyle.Fill;
            parent.Controls.Clear();
            parent.Controls.Add(target);
        }
    }
}