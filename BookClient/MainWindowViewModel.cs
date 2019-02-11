using BookClient.Model;
using MVVMHelperLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookClient
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _suchbegriff;

        public string Suchbegriff
        {
            get { return _suchbegriff; }
            set
            {
                _suchbegriff = value;
                SuchCommand.OnCanExecuteChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Suchbegriff)));
            }
        }

        private Book[] _buchErgebnisse;

        public Book[] Buchergebnisse
        {
            get { return _buchErgebnisse; }
            set
            {
                _buchErgebnisse = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Buchergebnisse)));
            }
        }

        private string _header = "Suchergebnisse";

        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Header)));
            }
        }



        public DelegateCommand SuchCommand { get; set; }
        public DelegateCommand FavoritenCommand { get; set; }
        public DelegateCommand AddFavoriteCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            SuchCommand = new DelegateCommand(async p =>
            {
                Buchergebnisse = (await BookSearchService.Suche(Suchbegriff)).ToArray();
            },
            p => !string.IsNullOrWhiteSpace(Suchbegriff));

            FavoritenCommand = new DelegateCommand(p =>
            {
                Header = "Favoriten";
                Buchergebnisse = FavoritenManager.Favoriten.ToArray();
            },
            p => FavoritenManager.Favoriten.Count > 0);

            AddFavoriteCommand = new DelegateCommand(p =>
            {
                if(p is Book book)
                {
                    FavoritenManager.Favoriten.Add(book);
                    FavoritenCommand.OnCanExecuteChanged();
                }
            });
        }
    }
}
