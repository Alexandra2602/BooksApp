using BooksApp.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private ObservableCollection<Book> myrootobject;
        public ProfilePage()
        {
            InitializeComponent();
        }

        async void Top_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TopPage());
        }
        async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksPage());
        }
        async void New_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewsPage());
        }
        async void Calendar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalendarPage());
        }
        async void Profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        async void My_Profile_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyProfile());

        }
        async void Logout_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsersPage());

        }
    }
}
    