using BooksApp.Models;
using System;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminMembersPage : ContentPage
    {
        public AdminMembersPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                var users = conn.Table<User>().ToList();
                userslistview.ItemsSource = users;
            }
        }
        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedUser = userslistview.SelectedItem as User;
            if (selectedUser != null)
            {
                Navigation.PushAsync(new AdminEditMembersPage(selectedUser));
            }     
        }
        async void AddUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminAddUser
            {
                BindingContext = new User()
            });
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMembersPage());
        }
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMainPage());
        }
        async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminRatingPage());
        }
        async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminReviewPage());
        }
        async void Button_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        async void Button_Clicked_5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminFinishedBooksPage());
        }
    }
}