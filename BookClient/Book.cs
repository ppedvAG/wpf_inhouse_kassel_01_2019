using System.ComponentModel;

namespace BookClient
{

    public class Book : INotifyPropertyChanged
    {
        public string id { get; set; }
        public Volumeinfo volumeInfo { get; set; }

        private bool _favorit = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Favorit
        {
            get { return _favorit; }
            set
            {
                _favorit = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Favorit)));
            }

        }
    }

    public class Volumeinfo
    {
        public string title { get; set; }
        public string previewLink { get; set; }
        public string[] authors { get; set; }
        public Imagelinks imageLinks { get; set; }
    }

    public class Imagelinks
    {
        public string smallThumbnail { get; set; }
    }
}