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

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksPage());
        }

        async void Read_Clicked(object sender, EventArgs e)
        {
            
            button1.TextColor = Color.FromHex("#9a7c5b");
            button1.BackgroundColor=Color.FloralWhite;
            button2.TextColor = Color.FloralWhite;
            button2.BackgroundColor = Color.FromHex("#9a7c5b");
            button3.TextColor = Color.FloralWhite;
            button3.BackgroundColor = Color.FromHex("#9a7c5b");

        }
        async void Reading_Clicked(object sender, EventArgs e)
        {
            button2.TextColor = Color.FromHex("#9a7c5b");
            button2.BackgroundColor = Color.FloralWhite;
            button1.TextColor = Color.FloralWhite;
            button1.BackgroundColor = Color.FromHex("#9a7c5b");
            button3.TextColor = Color.FloralWhite;
            button3.BackgroundColor = Color.FromHex("#9a7c5b");

        }
        async void Dropped_Clicked(object sender, EventArgs e)
        {
            button3.TextColor = Color.FromHex("#9a7c5b");
            button3.BackgroundColor = Color.FloralWhite;
            button2.TextColor = Color.FloralWhite;
            button2.BackgroundColor = Color.FromHex("#9a7c5b");
            button1.TextColor = Color.FloralWhite;
            button1.BackgroundColor = Color.FromHex("#9a7c5b");

        }


    }
}