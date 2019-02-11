using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace PersonenFormular
{
    public class DrawingColorToWindowsColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is System.Drawing.Color drawingColor)
            {
                return Color.FromRgb(drawingColor.R, drawingColor.G, drawingColor.B);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Color windowColor)
            {
                return System.Drawing.Color.FromArgb(windowColor.R, windowColor.G, windowColor.B);
            }
            return value;
        }
    }
}
