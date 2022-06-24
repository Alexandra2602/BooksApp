using BooksApp.Models;
using SQLite;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        User ul;
        public LoginPage()
        {
            InitializeComponent();
            EntryUser.Text = Preferences.Get("EntryUser", string.Empty);
            EntryPassword.Text = Preferences.Get("EntryPassword", string.Empty);

        }
        private void Login_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                if (EntryUser.Text == "admin" && EntryPassword.Text == "admin")
                {
                    App.Current.MainPage = new NavigationPage(new AdminMainPage());
                }
                var myquery = conn.Table<User>().Where(u => u.Email.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();
                if (myquery != null)
                {
                    var user = myquery as User;
                    App.Current.MainPage = new NavigationPage(new BooksPage(user));
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await this.DisplayAlert("Error", "Email or password is incorrect", "Ok", "Cancel");
                    });
                } 
            }
        }
        async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
        void SaveUsername()
        {
            if (checkbox1.IsChecked == true)
            {
                Preferences.Set("EntryUser", EntryUser.Text);
                Preferences.Set("EntryPassword", EntryPassword.Text);
                checkbox2.IsEnabled = false;
            }
            else
                Preferences.Clear();
        }
        private void checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (checkbox1.IsChecked == true)
            {
                Preferences.Set("EntryUser", EntryUser.Text);
                Preferences.Set("EntryPassword", EntryPassword.Text);
            }
            checkbox2.IsEnabled = false;
        }
        private void checkbox2_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Preferences.Clear();
            checkbox1.IsEnabled = false;
        }
    }
}