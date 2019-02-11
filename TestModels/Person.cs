using System;
using System.ComponentModel;
using System.Drawing;

namespace TestModels
{
    public class Person : INotifyPropertyChanged
    {
        private Color _lieblingsfarbe = Color.Red;

        public Color Lieblingsfarbe
        {
            get { return _lieblingsfarbe; }
            set
            {
                _lieblingsfarbe = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lieblingsfarbe)));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
