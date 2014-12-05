using System.Drawing;
using System.Windows.Forms;

namespace SharedClasses.Events
{
    public class InteractiveMouseDownEventArgs : MouseEventArgs
    {
        public InteractiveMouseDownEventArgs(MouseButtons button, int clicks, int x, int y, int delta)
            : base(button, clicks, x, y, delta)
        {
        }

        public InteractiveMouseDownEventArgs(MouseEventArgs e, float relativeX, float relativeY)
            : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
        {
            RelativeX = relativeX;
            RelativeY = relativeY;
        }

        public float RelativeX { protected get; set; }
        public float RelativeY { protected get; set; }

        public PointF RelativePoint
        {
            get { return new PointF(RelativeX, RelativeY); }
        }
    }
}