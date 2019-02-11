using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace PersonenFormular
{
    public class ColorManager
    {
        public static Color GetColor(DependencyObject obj)
        {
            return (Color)obj.GetValue(ColorProperty);
        }

        public static void SetColor(DependencyObject obj, Color value)
        {
            obj.SetValue(ColorProperty, value);
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.RegisterAttached("Color", typeof(Color), typeof(ColorManager), new PropertyMetadata(default(Color)));



    }
}
