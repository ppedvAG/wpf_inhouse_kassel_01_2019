using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ListBoxAffäre
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void DockPanel_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is DockPanel panel)
            {
                //finde das ListBox-Element und setze des SelectedItem auf den aktuellen DataContext
                DependencyObject currentElement = panel;
                do
                {
                    currentElement = VisualTreeHelper.GetParent(currentElement);
                } while (!(currentElement is ListBox));

                if (currentElement is ListBox box)
                {
                    box.SelectedItem = panel.DataContext;
                }
            }
        }
    }
}
