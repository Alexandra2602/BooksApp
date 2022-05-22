using BooksApp.Models;
using SQLite;
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
    public partial class UsersPage : ContentPage
    {
        User ul;
        public UsersPage(User ulist)
        {
            InitializeComponent();
            ul = ulist;
        }
        protected override  void OnAppearing()
        {
            base.OnAppearing();  
            toolbaritem.Text = "Logged in as " + ul.Name;
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                var users = conn.Table<User>().ToList();
                userslistview.ItemsSource = users;
            }
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new UsersDetailPage()
                {
                    BindingContext = e.SelectedItem as User
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