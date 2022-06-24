using BooksApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopPage : ContentPage
    {
        User ul;
        Book bl;
        public TopPage(User ulist)
        {
            InitializeComponent();
            ul = ulist;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listViewTop.ItemsSource = await App.Database.GetBookByRating();
            toolbaritem.Text = "Logged in as " + ul.Name;
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Book bl = (Book)e.SelectedItem;
                await Navigation.PushAsync(new ReviewDetailsPage(ul,bl)
                {
                    BindingContext = e.SelectedItem as Book
                });
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