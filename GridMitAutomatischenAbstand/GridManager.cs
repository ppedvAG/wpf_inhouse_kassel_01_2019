using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GridMitAutomatischenAbstand
{
    public class GridManager
    {
        public static double GetLeftMargin(DependencyObject obj)
        {
            return (double)obj.GetValue(LeftMarginProperty);
        }

        public static void SetLeftMargin(DependencyObject obj, double value)
        {
            obj.SetValue(LeftMarginProperty, value);
        }

        // Using a DependencyProperty as the backing store for LeftMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftMarginProperty =
            DependencyProperty.RegisterAttached("LeftMargin", typeof(double), typeof(GridManager), new PropertyMetadata(-1.0,LeftMarginChanged));

        private static void LeftMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is Grid grid)
            {
                grid.Loaded += (sen, ee) =>
                {
                    foreach (var item in grid.Children)
                    {
                        if(item is FrameworkElement element)
                        {
                            element.Margin = Grid.GetRow(element) == GetRowNumber(d) ? new Thickness(0) : new Thickness((double)e.NewValue, 0, 0, 0); 
                        }
                    }
                };
            }
        }

        public static int GetRowNumber(DependencyObject obj)
        {
            return (int)obj.GetValue(RowNumberProperty);
        }

        public static void SetRowNumber(DependencyObject obj, int value)
        {
            obj.SetValue(RowNumberProperty, value);
        }

        // Using a DependencyProperty as the backing store for RowNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowNumberProperty =
            DependencyProperty.RegisterAttached("RowNumber", typeof(int), typeof(GridManager), new PropertyMetadata(0));


    }
}
