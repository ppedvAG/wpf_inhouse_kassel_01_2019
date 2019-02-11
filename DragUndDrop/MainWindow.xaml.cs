using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DragUndDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed && sender is TextBlock block)
            {
                DataObject obj = new DataObject(typeof(Brush), block.Foreground);

                DragDrop.DoDragDrop(sender as TextBlock, obj, DragDropEffects.Copy);
            }
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(Brush)) && e.AllowedEffects == DragDropEffects.Copy && sender is Rectangle rect)
            {
                rect.Fill = e.Data.GetData(typeof(Brush)) as Brush;
            }
        }

        private void Rectangle_DragOver(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(Brush)) && e.AllowedEffects == DragDropEffects.Copy)
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                if(sender is Rectangle rect)
                {
                    rect.AllowDrop = false;
                }
                e.Effects = DragDropEffects.None;
            }
        }
    }
}
