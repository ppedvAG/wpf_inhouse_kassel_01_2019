using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PersonenFormular
{
    public class UniformPanelHelper
    {
        //snippet: propa

        public static bool GetNormalizeWidth(DependencyObject obj)
        {
            return (bool)obj.GetValue(NormalizeWidthProperty);
        }

        public static void SetNormalizeWidth(DependencyObject obj, bool value)
        {
            obj.SetValue(NormalizeWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for NormalizeWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NormalizeWidthProperty =
            DependencyProperty.RegisterAttached("NormalizeWidth", typeof(bool), typeof(UniformPanelHelper), new PropertyMetadata(false,NormalizeWidthChanged));

        private static void NormalizeWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is Panel panel && (bool)e.NewValue == true)
            {
                panel.LayoutUpdated += (sen, asda) =>
                {
                    double maxWidth = 0;
                    foreach (UIElement item in panel.Children)
                    {
                        if (item is FrameworkElement element)
                        {
                            if (element.ActualWidth > maxWidth)
                            {
                                maxWidth = element.ActualWidth;
                            }
                        }
                    }
                    foreach (UIElement item in panel.Children)
                    {
                        if (item is FrameworkElement element)
                        {
                            element.Width = maxWidth;
                        }
                    }
                };
            }
        }
    }
}
