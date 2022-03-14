using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.ViewModels
{
    public class BookDetailViewModel: BaseViewModel
    {
        private Book _book;
        public Book Book
        {
            get => _book;
            set
            {
                SetValue(ref _book, value);
            }
        }

        public BookDetailViewModel(Book book)
        {
            this.Book = book;
        }
    }
}
