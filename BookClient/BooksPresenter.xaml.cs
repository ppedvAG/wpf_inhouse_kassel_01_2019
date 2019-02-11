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

namespace BookClient
{
    /// <summary>
    /// Interaction logic for BooksPresenter.xaml
    /// </summary>
    public partial class BooksPresenter : UserControl
    {
        public IEnumerable<Book> Books
        {
            get { return (IEnumerable<Book>)GetValue(BooksProperty); }
            set { SetValue(BooksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Books.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BooksProperty =
            DependencyProperty.Register("Books", typeof(IEnumerable<Book>), typeof(BooksPresenter), new PropertyMetadata(null));




        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(BooksPresenter), new PropertyMetadata(null));


        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(BooksPresenter), new PropertyMetadata(null));



        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(BooksPresenter), new PropertyMetadata(null));



        public BooksPresenter()
        {
            InitializeComponent();
            mainPanel.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                if(button.DataContext is Book book)
                {
                    ButtonCommand?.Execute(book);
                }
            }
        }
    }
}
