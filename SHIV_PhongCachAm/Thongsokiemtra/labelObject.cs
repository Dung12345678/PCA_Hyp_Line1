using System.Windows.Media;

namespace SHIV_PhongCachAm
{
    public class labelObject : ObservableObject
    {
        private string _label;
        private Brush _color;

        public labelObject()
        {
            _label = "";
        }

        public string Value
        {
            get { return _label; }
            set
            {
                _label = value;
                OnPropertyChanged("Value");
            }
        }
        public Brush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

    }
}
