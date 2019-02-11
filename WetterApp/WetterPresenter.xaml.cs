using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WetterApp
{
    /// <summary>
    /// Interaction logic for WetterPresenter.xaml
    /// </summary>
    public partial class WetterPresenter : UserControl
    {
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(WetterPresenter), new PropertyMetadata(null));

        public Stadt Stadt
        {
            get { return (Stadt)GetValue(StadtProperty); }
            set { SetValue(StadtProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stadt.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StadtProperty =
            DependencyProperty.Register("Stadt", typeof(Stadt), typeof(WetterPresenter), new PropertyMetadata(null, StadtChanged));

        private static async void StadtChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is WetterPresenter presenter)
            {
                if(e.OldValue is Stadt oldStadt)
                {
                    oldStadt.PropertyChanged -= Stadt_PropertyChanged;
                }
                if(e.NewValue is Stadt stadt)
                {
                    stadt.PropertyChanged += Stadt_PropertyChanged;
                    await GetAPIResult(stadt);
                }
            }
        }

        private static async void Stadt_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(sender is Stadt stadt && e.PropertyName == nameof(WetterApp.Stadt.Name))
            {
                await GetAPIResult(stadt);
            }
        }

        private static async Task GetAPIResult(Stadt stadt)
        {
            try
            {
                stadt.Temperatur = null;
                HttpClient client = new HttpClient();
                var jsonString = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={stadt.Name}&units=metric&appid=84d84c7b399d88e7f4e4688facc2498e");
                await Task.Delay(1000);
                var result = JsonConvert.DeserializeObject<WetterAPIResult>(jsonString);
                stadt.Temperatur = result.main.temp;
                stadt.IconURL = $"http://openweathermap.org/img/w/{result.weather[0].icon}.png";
                stadt.ErrorMessage = null;
            }
            catch (Exception exp)
            {
                stadt.ErrorMessage = exp.Message;
                stadt.Temperatur = 0;
            }
        }

        public WetterPresenter()
        {
            InitializeComponent();
            mainGrid.DataContext = this;
        }
    }
}
