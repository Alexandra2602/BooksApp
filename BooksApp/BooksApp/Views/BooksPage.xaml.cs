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
            
            public BooksPage()
            {

                InitializeComponent();
                
            }
            protected override async void OnAppearing()
            {
                base.OnAppearing();
                listView.ItemsSource = await App.Database.GetBookListsAsync();
            }

            async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new DetailPage
                    {
                        BindingContext = e.SelectedItem as Book
                    });
                }
            }
            async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
            {
                var search = Search1.Text.ToLower();
                //var searchresult= App.Database.SearchBookAsync(search);
                //listView.ItemsSource = await App.Database.SearchBookAsync(search);

            }
            async void Top_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new TopPage());
            }
            async void Home_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new BooksPage());
            }
         
            async void Calendar_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new CalendarPage());
            }
            async void Profile_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new ProfilePage());
            }
            async void Members_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new UsersPage());
            }

        }
    }