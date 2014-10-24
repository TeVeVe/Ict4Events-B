using System.Drawing;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    /// <summary>
    ///     An interactive map for displaying locational information on an image.
    /// </summary>
    public partial class InteractiveMap : Control
    {
        public InteractiveMap()
        {
            InitializeComponent();
            SetStyle(
                ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
        }


        /// <summary>
        ///     Image that will be used as a background to draw spots on.
        /// </summary>
        public Image ImageMap { get; set; }

        /// <summary>
        ///     Detemines if <see cref="ImageMap" /> should be drawn in pixel size or scaled (and stretched) to control size.
        /// </summary>
        public bool DrawImageRealSize { get; set; }

        /// <summary>
        ///     Bounds of the map. Same as image if <see cref="DrawImageRealSize" /> is True.
        ///     Else it's the Width and Height of this control.
        /// </summary>
        public Rectangle MapBounds
        {
            get
            {
                var destRect = new Rectangle();
                if (ImageMap != null && DrawImageRealSize)
                {
                    destRect.Width = ImageMap.Width;
                    destRect.Height = ImageMap.Height;
                }
                else
                {
                    destRect.Width = Width;
                    destRect.Height = Height;
                }

                return destRect;
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // Draw the map on the background.
            Rectangle destRect = MapBounds;
            if (destRect != null)
                pe.Graphics.DrawImage(ImageMap, destRect);

            // Draw spots on map.
            pe.Graphics.DrawRectangle(Pens.Red, destRect);
        }

        /// <summary>
        ///     A location on the interactive map.
        /// </summary>
        public class Spot
        {
            public Spot(PointF position)
            {
                Position = position;
                Size = new SizeF(5, 5);
                Scale = 1;
            }

            public Spot(PointF position, object tag)
                : this(position)
            {
                Tag = tag;
            }

            public PointF Position { get; set; }
            public object Tag { get; set; }
            public SizeF Size { get; set; }
            public float Scale { get; set; }
        }
    }
}