using BooksApp.Models;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksPage : ContentPage
    {
        private ObservableCollection<Book> myrootobject;
        public BooksPage()
        {
            InitializeComponent();
            BindingContext = this;

            var assembly = typeof(BooksPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("BooksApp.books.json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                List<Book> mylist = JsonConvert.DeserializeObject<List<Book>>(json);
                myrootobject = new ObservableCollection<Book>(mylist);
                MyListView.ItemsSource = myrootobject;

            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = myrootobject.Where(c => c.Title.ToLower().Contains(Search1.Text.ToLower()) ||c.Author.ToLower().Contains(Search1.Text.ToLower()));
           
            MyListView.ItemsSource = searchresult;
        }

         async private void MyListView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Book tappedbook = e.Item as Book;
            if (tappedbook == null)
                return;

        }

        async void MyListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var bookDetailPage = new BookDetailPage(e.SelectedItem as Book);
            await Navigation.PushAsync(bookDetailPage);

        }

    
    }

    }
        
    
