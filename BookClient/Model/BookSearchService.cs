using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookClient.Model
{
    public class BookSearchService
    {
        public static async Task<ObservableCollection<Book>> Suche(string suchbegriff)
        { 
            HttpClient client = new HttpClient();

            string jsonString = await client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={suchbegriff}");
            await Task.Delay(1000);
            BookSearchResult result = JsonConvert.DeserializeObject<BookSearchResult>(jsonString);

            return new ObservableCollection<Book>(result.items);
        }
    }
}