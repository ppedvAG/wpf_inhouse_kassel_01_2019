using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WetterApp
{
    /// <summary>
    /// Wenn der value null oder empty ist -> Collapsed
    /// Ansonsten Visible
    /// Bei parameter == true -> umgedreht
    /// </summary>
    public class StringToVisibilityConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           bool dontShow = false;

            if(value == null)
            {
                dontShow = true;
            }

            else if(value is string message)
            {
                dontShow = string.IsNullOrWhiteSpace(message);
            }

            else if(double.TryParse(value?.ToString(), out double d))
            {
                dontShow = false;
            }
   
            //Drehe den Wert um, wenn der ConverterParameter true ist
            if(bool.TryParse(parameter?.ToString(),out bool b) && b == true)
            {
                dontShow = !dontShow;
            }

            return dontShow ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
