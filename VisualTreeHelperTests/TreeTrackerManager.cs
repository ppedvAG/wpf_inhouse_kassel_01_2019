using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace VisualTreeHelperTests
{
    public class TreeTrackerManager
    {

        public static bool GetLogicalTrackerRoot(DependencyObject obj)
        {
            return (bool)obj.GetValue(LogicalTrackerRootProperty);
        }

        public static void SetLogicalTrackerRoot(DependencyObject obj, bool value)
        {
            obj.SetValue(LogicalTrackerRootProperty, value);
        }

        // Using a DependencyProperty as the backing store for LogicalTrackerRoot.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LogicalTrackerRootProperty =
            DependencyProperty.RegisterAttached("LogicalTrackerRoot", typeof(bool), typeof(TreeTrackerManager), new PropertyMetadata(false, LogicalTrackerRootChanged));

        private static void LogicalTrackerRootChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && (bool)e.NewValue == true)
            {
                element.AddHandler(FrameworkElement.MouseUpEvent, new MouseButtonEventHandler(MouseUpLogical), true);
            }
        }

        private static void MouseUpLogical(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is DependencyObject)
            {
                DependencyObject currentElement = e.OriginalSource as DependencyObject;
                LogicalDisplayers.ForEach(d => d.Children.Clear());
                bool print = true;
                do
                {
                    if (print)
                    {

                        foreach (var item in LogicalDisplayers)
                        {
                            TextBlock block = new TextBlock();
                            block.Text = currentElement.ToString();
                            if (currentElement is FrameworkElement element)
                            {
                                block.ToolTip = "DataContext: " + element.DataContext?.ToString();
                            }
                            else if (currentElement is FrameworkContentElement celement)
                            {
                                block.ToolTip = "DataContext: " + celement.DataContext?.ToString();
                            }
                            item.Children.Add(block);
                        }
                    }
                    print = true;
                    DependencyObject nextElement = LogicalTreeHelper.GetParent(currentElement);
                    if (nextElement == null)
                    {
                        if (currentElement is FrameworkElement fe)
                        {
                            nextElement = fe.TemplatedParent ?? fe.Parent;
                        }
                        else if (currentElement is FrameworkContentElement fce)
                        {
                            nextElement = fce.TemplatedParent ?? fce.Parent;
                        }
                        if (nextElement == null)
                        {
                            nextElement = VisualTreeHelper.GetParent(currentElement);
                            print = false;
                        }
                    }
                    currentElement = nextElement;
                } while (currentElement != null);
            }
        }

        public static bool GetIsTrackerRoot(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsTrackerRootProperty);
        }

        public static void SetIsTrackerRoot(DependencyObject obj, bool value)
        {
            obj.SetValue(IsTrackerRootProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsTrackerRoot.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTrackerRootProperty =
            DependencyProperty.RegisterAttached("IsTrackerRoot", typeof(bool), typeof(TreeTrackerManager), new PropertyMetadata(false, TrackerRootChanged));



        private static void TrackerRootChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && (bool)e.NewValue == true)
            {
                element.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(MouseUp), true);
            }
        }

        private static void MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is DependencyObject)
            {
                DependencyObject currentElement = e.OriginalSource as DependencyObject;
                TreeDisplayers.ForEach(d => d.Children.Clear());
                do
                {
                    foreach (var item in TreeDisplayers)
                    {
                        TextBlock block = new TextBlock();
                        block.Text = currentElement.ToString();
                        if (currentElement is FrameworkElement element)
                        {
                            block.ToolTip = "DataContext: " + element.DataContext?.ToString();
                        }
                        else if (currentElement is FrameworkContentElement celement)
                        {
                            block.ToolTip = "DataContext: " + celement.DataContext?.ToString();
                        }
                        item.Children.Add(block);
                    }
                    if (currentElement is Visual || currentElement is Visual3D)
                        currentElement = VisualTreeHelper.GetParent(currentElement);
                    else
                    {
                        currentElement = LogicalTreeHelper.GetParent(currentElement);
                    }
                } while (currentElement != null);
            }
        }

        public static List<Panel> TreeDisplayers = new List<Panel>();

        public static bool GetTreeDisplayer(DependencyObject obj)
        {
            return (bool)obj.GetValue(TreeDisplayerProperty);
        }

        public static void SetTreeDisplayer(DependencyObject obj, bool value)
        {
            obj.SetValue(TreeDisplayerProperty, value);
        }

        // Using a DependencyProperty as the backing store for TreeDisplayer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TreeDisplayerProperty =
            DependencyProperty.RegisterAttached("TreeDisplayer", typeof(bool), typeof(TreeTrackerManager), new PropertyMetadata(false, TreeDislayerChanged));

        private static void TreeDislayerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Panel panel)
            {
                TreeDisplayers.Add(panel);
            }
        }


        public static bool GetLogicalDisplayer(DependencyObject obj)
        {
            return (bool)obj.GetValue(LogicalDisplayerProperty);
        }

        public static void SetLogicalDisplayer(DependencyObject obj, bool value)
        {
            obj.SetValue(LogicalDisplayerProperty, value);
        }

        // Using a DependencyProperty as the backing store for LogicalDisplayer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LogicalDisplayerProperty =
            DependencyProperty.RegisterAttached("LogicalDisplayer", typeof(bool), typeof(LogicalTreeHelper), new PropertyMetadata(false, LogicalDisplayerChanged));

        private static void LogicalDisplayerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Panel panel)
            {
                LogicalDisplayers.Add(panel);
            }
        }

        public static List<Panel> LogicalDisplayers = new List<Panel>();
    }
}
