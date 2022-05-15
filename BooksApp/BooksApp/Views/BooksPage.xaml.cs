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

        User ul;
        public BooksPage(User ulist)
        {
            InitializeComponent();
            ul = ulist;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetBookListsAsync();

            toolbaritem.Text = "You are logged in as " + ul.Name;
            
            
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DetailPage(ul)
                {
                    BindingContext = e.SelectedItem as Book
                });
            }
        }
        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchValue = Search1.Text;
            if(!String.IsNullOrEmpty(searchValue))
            {
                var books = await App.Database.GetBooksByTitle(searchValue);
                listView.ItemsSource = null;
                listView.ItemsSource = books;
            }
            else
            {
                OnAppearing();
            }
        }
        async void Search1_SearchButtonPressed(object sender, EventArgs e)
        {
            string searchValue = Search1.Text;
            if (!String.IsNullOrEmpty(searchValue))
            {
                var books = await App.Database.GetBooksByTitle(searchValue);
                listView.ItemsSource = null;
                listView.ItemsSource = books;
            }
            else
            {
                OnAppearing();
            }
        }
        async void Top_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TopPage(ul));
        }
        async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksPage(ul));
        }
        async void Calendar_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new CalendarPage(ul));
        }
        async void Profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(ul));
        }
        async void Members_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsersPage(ul));
        }
    }
}