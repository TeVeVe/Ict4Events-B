using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    /// <summary>
    ///     An interactive map for displaying locational information on an image.
    /// </summary>
    public partial class InteractiveMap : Control
    {
        private bool _drawImageRealSize;
        private Image _imageMap;

        public InteractiveMap()
        {
            Spots = new List<Spot>();

            InitializeComponent();
            SetStyle(
                ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
        }


        /// <summary>
        ///     Image that will be used as a background to draw spots on.
        /// </summary>
        public Image ImageMap
        {
            get { return _imageMap; }
            set
            {
                _imageMap = value;
                Invalidate();
            }
        }

        /// <summary>
        ///     Detemines if <see cref="ImageMap" /> should be drawn in pixel size or scaled (and stretched) to control size.
        /// </summary>
        public bool DrawImageRealSize
        {
            get { return _drawImageRealSize; }
            set
            {
                _drawImageRealSize = value;
                Invalidate();
            }
        }

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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Spot> Spots { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // Draw the map on the background.
            Rectangle destRect = MapBounds;
            if (ImageMap != null)
                pe.Graphics.DrawImage(ImageMap, destRect);

            // Draw spots on map.
            foreach (Spot spot in Spots)
            {
                RectangleF drawRect = spot.VisualBounds;
                pe.Graphics.DrawRectangle(new Pen(spot.Color), drawRect.X, drawRect.Y, drawRect.Width, drawRect.Height);
            }
        }

        /// <summary>
        ///     A location on the interactive map.
        /// </summary>
        public class Spot
        {
            public Spot(PointF position)
            {
                Position = position;
                Color = Color.Black;
                Size = new SizeF(10, 10);
            }

            public Spot(PointF position, object tag)
                : this(position)
            {
                Tag = tag;
            }

            public Spot(float x, float y) : this(new PointF(x, y))
            {
            }

            public Color Color { get; set; }
            public PointF Position { get; set; }
            public object Tag { get; set; }
            public SizeF Size { get; set; }

            public RectangleF VisualBounds
            {
                get
                {
                    return new RectangleF(Position.X - (Size.Width / 2), Position.Y - (Size.Height / 2), Size.Width,
                        Size.Height);
                }
            }
        }
    }
}