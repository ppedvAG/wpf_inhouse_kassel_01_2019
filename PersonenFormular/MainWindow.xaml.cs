using PersonenModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonenFormular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DoubleAnimation _ausblendAnimation;

        public MainWindow()
        {
            InitializeComponent();
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(200);
                    this.Dispatcher.Invoke(() =>
                    {
                        textboxName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    });
                }
            });
            thread.IsBackground = true;
            thread.Start();

            _ausblendAnimation = new DoubleAnimation(wrap.ActualWidth, new Duration(TimeSpan.FromSeconds(1)), FillBehavior.Stop);
            _ausblendAnimation.Completed += Ausblenden_Animation_Completed;

            this.AddHandler(FrameworkElement.MouseUpEvent, new MouseButtonEventHandler(Window_MouseUp),true);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is RadioButton button)
            {
                if(this.DataContext is MainWindowViewModel model)
                {
                    model.NeuePerson.Lieblingsfarbe = ColorManager.GetColor(button);
                }
            }
        }

        private int _clicks;

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _clicks++;
            this.Title = $"Clicks: {_clicks}, Clicks im Grid: {_clicksGrid}";

            e.Handled = true;
        }

        private int _clicksGrid;

        private void Grid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _clicksGrid++;
            this.Title = $"Clicks: {_clicks}, Clicks im Grid: {_clicksGrid}";
        }

        private void Button_Ausblenden_Klick(object sender, RoutedEventArgs e)
        {
            _ausblendAnimation.To = wrap.ActualWidth;
            renderWrapPanel.BeginAnimation(TranslateTransform.XProperty, _ausblendAnimation);
        }

        private void Ausblenden_Animation_Completed(object sender, EventArgs e)
        {
            renderWrapPanel.X = wrap.ActualWidth;
            wrap.Visibility = Visibility.Collapsed;
        }

        private void Einblenden_Animation_Completed(object sender, EventArgs e)
        {
            renderWrapPanel.X = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wrap.Visibility = Visibility.Visible;
        }
    }
}
