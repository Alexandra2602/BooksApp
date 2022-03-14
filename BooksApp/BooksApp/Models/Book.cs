using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Models
{
    public class Book
    {
        [JsonProperty(PropertyName ="bookId")]
        public int BookId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        [JsonProperty(PropertyName = "numberOfPages")]
        public int NumberOfPages { get; set; }

        [JsonProperty(PropertyName = "yearPublished ")]
        public int YearPublished { get; set; }

        public string Image { get; set; }
        

    }

    public class BookList
    {
        public List <Book> books { get; set; }

    }
}
