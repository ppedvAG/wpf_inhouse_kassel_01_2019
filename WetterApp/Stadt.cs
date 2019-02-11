using MVVMHelperLibrary;
using System.ComponentModel;

namespace WetterApp
{
    public class Stadt : ModelBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetValue(ref _name, value);
            }
        }

        private double? _temperatur;
        public double? Temperatur
        {
            get { return _temperatur; }
            set
            {
                SetValue(ref _temperatur, value);
            }
        }


        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                SetValue(ref _errorMessage, value);
            }
        }


        private string _iconURL;
        public string IconURL
        {
            get { return _iconURL; }
            set
            {
                SetValue(ref _iconURL, value);
            }
        }

        public Stadt(string name)
        {
            Name = name;
        }

        public Stadt()
        {

        }
    }
}