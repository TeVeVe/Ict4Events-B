using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SharedClasses.Extensions;

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
            Spots = new SpotCollection(this);
            Spots.SpotHover += (sender, args) => OnSpotHover(args);

            InitializeComponent();
            SetStyle(
                ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

            MouseMove += OnMouseMove;
            MouseDown += OnMouseDown;
        }

        public bool KeepAspectRatio { get; set; }


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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
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
                    if (KeepAspectRatio && ImageMap != null)
                    {
                        double ratioX = Width / (double)ImageMap.Width;
                        double ratioY = Height / (double)ImageMap.Height;
                        double ratio = ratioX < ratioY ? ratioX : ratioY;

                        destRect.Width = (int)(ImageMap.Width * ratio);
                        destRect.Height = (int)(ImageMap.Height * ratio);
                    }
                    else
                    {
                        destRect.Width = Width;
                        destRect.Height = Height;
                    }
                }

                return destRect;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SpotCollection Spots { get; set; }

        public event EventHandler<SpotHoverEventArgs> SpotHover;
        public event EventHandler<SpotClickEventArgs> SpotClick;

        protected virtual void OnSpotClick(SpotClickEventArgs e)
        {
            EventHandler<SpotClickEventArgs> handler = SpotClick;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnSpotHover(SpotHoverEventArgs e)
        {
            EventHandler<SpotHoverEventArgs> handler = SpotHover;
            if (handler != null)
                handler(this, e);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            foreach (Spot spot in Spots)
            {
                var mouseRect = new Rectangle(e.X - 1, e.Y - 1, 1, 1);
                spot.IsHover = spot.VisualBounds.IntersectsWith(mouseRect);
            }
            Invalidate();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            // Only with the left mouse button.
            if (e.Button != MouseButtons.Left)
                return;

            // Check if a spot is currently being hovered. If so, it's now clicked as well.
            foreach (Spot spot in Spots.Where(spot => spot.IsHover))
                OnSpotClick(new SpotClickEventArgs(spot));
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // Draw the map on the background.
            Rectangle destRect = MapBounds;
            if (ImageMap != null)
                pe.Graphics.DrawImage(ImageMap, destRect);

            // Draw spots on map.
            foreach (Spot spot in Spots)
                spot.Draw(pe.Graphics);
        }

        protected internal Spot Add(Spot spot)
        {
            spot.Map = this;
            Spots.Add(spot);
            return spot;
        }

        public Spot Add(float x, float y)
        {
            var spot = new Spot(x, y);
            spot.Map = this;
            Spots.Add(spot);
            return spot;
        }

        public Spot Add(double x, double y)
        {
            var spot = new Spot(x, y);
            spot.Map = this;
            Spots.Add(spot);
            return spot;
        }

        public void AddRange(IEnumerable<Spot> spots)
        {
            foreach (Spot spot in spots)
            {
                spot.Hovered += (sender, args) => OnSpotHover(args);
                Add(spot);
            }

            this.InvokeSafe(c =>
            {
                Invalidate();
                Update();
            });
        }

        public void Clear()
        {
            Spots.Clear();
            ImageMap = null;
        }

        /// <summary>
        ///     A location on the interactive map.
        /// </summary>
        public class Spot
        {
            private const float START_SIZE = 15;
            private const float MIN_SIZE = 10;
            private bool _isHover;
            private SizeF _size;

            protected internal Spot(PointF position)
            {
                Position = position;
                Color = Color.Black;
                Size = new SizeF(START_SIZE, START_SIZE);
                Checked = true;
            }

            public Spot(PointF position, object tag)
                : this(position)
            {
                Tag = tag;
                BorderWidth = 5;
            }

            public Spot(float x, float y) : this(new PointF(x, y))
            {
            }

            public Spot(double locX, double locY) : this(new PointF((float)locX, (float)locY))
            {
            }

            public InteractiveMap Map { get; set; }

            public Color Color { get; set; }
            public PointF Position { get; set; }
            public object Tag { get; set; }

            public int BorderWidth { get; set; }

            public SizeF Size
            {
                get { return _size; }
                set
                {
                    if (value.Width < MIN_SIZE)
                        value.Width = MIN_SIZE;
                    if (value.Height < MIN_SIZE)
                        value.Height = MIN_SIZE;

                    _size = value;
                }
            }

            public bool? Checked { get; set; }

            public bool IsHover
            {
                get { return _isHover; }
                set
                {
                    if (_isHover == value)
                        return;
                    _isHover = value;
                    OnHovered(new SpotHoverEventArgs(this));
                }
            }

            public RectangleF VisualBounds
            {
                get
                {
                    return new RectangleF((Position.X * Map.MapBounds.Width) - (Size.Width / 2),
                        (Position.Y * Map.MapBounds.Height) - (Size.Height / 2), Size.Width,
                        Size.Height);
                }
            }

            public event EventHandler<SpotHoverEventArgs> Hovered;

            protected virtual void OnHovered(SpotHoverEventArgs e)
            {
                EventHandler<SpotHoverEventArgs> handler = Hovered;
                if (handler != null)
                    handler(this, e);
            }

            public void Draw(Graphics g)
            {
                RectangleF drawRect = VisualBounds;
                float scale = Size.Width / MIN_SIZE;

                // Graphics settings.
                g.SmoothingMode = SmoothingMode.HighQuality;

                if (!Checked.HasValue)
                    // Fill in the rectangle.
                    g.FillRectangle(new SolidBrush(Color), drawRect.X, drawRect.Y, drawRect.Width, drawRect.Height);
                else if (Checked.Value)
                {
                    // Draw border.
                    g.DrawRectangle(new Pen(Color, BorderWidth), drawRect.X, drawRect.Y, drawRect.Width, drawRect.Height);

                    // Draw check.
                    var linePen = new Pen(Color, 1 * scale);

                    // Draw left side of check.
                    g.DrawLine(linePen, drawRect.X + (1 * scale), drawRect.Y + (drawRect.Height / 2) - (1 * scale),
                        drawRect.X + (Size.Width / 2), drawRect.Y + Size.Height);

                    // Draw right side of check.
                    g.DrawLine(linePen, drawRect.X + Size.Width / 2, drawRect.Y + Size.Height,
                        drawRect.X + drawRect.Width - (2 * scale), drawRect.Y);
                }
                else
                    // Draw border only.
                    g.DrawRectangle(new Pen(Color, BorderWidth), drawRect.X, drawRect.Y, drawRect.Width, drawRect.Height);
            }
        }

        public class SpotClickEventArgs : EventArgs
        {
            public SpotClickEventArgs(Spot spot)
            {
                Spot = spot;
            }

            public Spot Spot { get; protected set; }
        }

        public class SpotCollection : Collection<Spot>
        {
            public SpotCollection(InteractiveMap map)
            {
                Map = map;
            }

            public SpotCollection(IList<Spot> list) : base(list)
            {
            }

            public InteractiveMap Map { get; set; }

            public event EventHandler<SpotHoverEventArgs> SpotHover;

            protected virtual void OnSpotHover(SpotHoverEventArgs e)
            {
                EventHandler<SpotHoverEventArgs> handler = SpotHover;
                if (handler != null)
                    handler(this, e);
            }

            public new void Add(Spot spot)
            {
                spot.Hovered += (sender, args) => OnSpotHover(args);
                base.Add(spot);
                Map.InvokeSafe(c =>
                {
                    Map.Invalidate();
                    Map.Update();
                });
            }

            public void AddRange(IEnumerable<Spot> spots)
            {
                foreach (Spot spot in spots)
                {
                    spot.Hovered += (sender, args) => OnSpotHover(args);
                    base.Add(spot);
                }

                Map.InvokeSafe(c =>
                {
                    Map.Invalidate();
                    Map.Update();
                });
            }
        }

        public class SpotHoverEventArgs : EventArgs
        {
            public SpotHoverEventArgs(Spot spot)
            {
                Spot = spot;
            }

            public Spot Spot { get; protected set; }
        }
    }
}