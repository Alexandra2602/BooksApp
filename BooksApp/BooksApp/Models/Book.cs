using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages { get; set; }
        public int YearPublished { get; set; }
        public string Image { get; set; }
        

    }

    public class BookList
    {
        public List <Book> books { get; set; }

    }
}
