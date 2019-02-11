using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Lokalisierungsvarianten
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is MenuItem item)
            {
                //2. Variante über Resx-Dateien
                string newLang = item.Tag.ToString().Contains("English") ? "en" : "de";
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(newLang);

                //Page muss neu geladen werden, nur notwendig bei StaticResource statt DynamicResource
                Application.Current.Resources.MergedDictionaries[0].Source = new Uri($"pack://application:,,,/Languages;component/{item.Tag}");
                mainFrame.Navigate(new MainPage());
            }
        }
    }
}
