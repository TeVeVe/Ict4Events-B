using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using FontFamily = System.Windows.Media.FontFamily;

namespace SharedClasses.Controls.WPF
{
    /// <summary>
    /// Interaction logic for InteractiveMap.xaml
    /// </summary>
    public partial class InteractiveMap
    {
        private ObservableCollection<Spot> _spots;
        private ImageSource _mapImage;

        public ImageSource MapImage
        {
            get { return _mapImage; }
            set
            {
                if (_mapImage == value) return;
                _mapImage = value;
                OnPropertyChanged("MapImage");
            }
        }

        public InteractiveMap()
        {
            InitializeComponent();

            _spots = new ObservableCollection<Spot>();

        }

        public ObservableCollection<Spot> Spots
        {
            get { return _spots; }
            set
            {
                if (Equals(value, _spots)) return;
                _spots = value;
                OnPropertyChanged("Spots");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Spot : INotifyPropertyChanged
    {
        private string _content;
        private double _fontSize;
        private bool _isAvailable;
        private Thickness _location;
        private Typeface _typeface;

        public Spot(Thickness location)
        {
            _location = location;
            _typeface = new Typeface(new FontFamily("Calibri"), FontStyles.Normal, FontWeights.Normal,
                FontStretches.Normal);
        }

        public Spot(double left, double top)
            : this(new Thickness(left, top, 0, 0))
        {
        }

        public Spot(double left, double top, bool isAvailable)
            : this(left, top)
        {
            _isAvailable = isAvailable;
        }

        public Thickness Location
        {
            get { return _location; }
            set
            {
                if (value.Equals(_location)) return;
                _location = value;
                OnPropertyChanged("Location");
                OnPropertyChanged("ContentLocation");
            }
        }

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set
            {
                if (value.Equals(_isAvailable)) return;
                _isAvailable = value;
                OnPropertyChanged("IsAvailable");
            }
        }

        public Thickness ContentLocation
        {
            get
            {
                var contentSize = new FormattedText(Content, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                    _typeface, FontSize, new SolidColorBrush(Colors.Black));
                return new Thickness(Location.Left - (contentSize.Width / 2), Location.Top - contentSize.Height, 0,
                    0);
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                if (value == _content) return;
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        public Typeface Typeface
        {
            get { return _typeface; }
            set
            {
                if (Equals(value, _typeface)) return;
                _typeface = value;
                OnPropertyChanged("Typeface");
            }
        }

        public double FontSize
        {
            get { return _fontSize; }
            set
            {
                if (value.Equals(_fontSize)) return;
                _fontSize = value;
                OnPropertyChanged("FontSize");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
