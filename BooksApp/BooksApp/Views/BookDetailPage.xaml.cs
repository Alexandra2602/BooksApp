using BooksApp.Models;
using BooksApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetailPage : ContentPage
    {
        BookDetailViewModel bookDetailViewModel;
        public BookDetailPage()
        {
            InitializeComponent();
        }

        public BookDetailPage(Book book)
        {
            InitializeComponent();
            bookDetailViewModel = new BookDetailViewModel(book);
            this.BindingContext = bookDetailViewModel;
        }
    }
}