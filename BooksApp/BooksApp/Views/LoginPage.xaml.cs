using BooksApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
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
                    App.Current.MainPage = new NavigationPage(new BooksPage());
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await this.DisplayAlert("Error", "You have to enter an username and a password", "Ok", "Cancel");

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
            if (checkbox.IsChecked == true)
            {
                Preferences.Set("EntryUser", EntryUser.Text);
                Preferences.Set("EntryPassword", EntryPassword.Text);
            }
            else
                Preferences.Clear();
        }

        private void checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (checkbox.IsChecked == true)
            {
                Preferences.Set("EntryUser", EntryUser.Text);
                Preferences.Set("EntryPassword", EntryPassword.Text);
            }
            checkbox2.IsEnabled = false;

        }
        private void checkbox2_CheckedChanged(object sender, CheckedChangedEventArgs e)
        { 
                Preferences.Clear();
            checkbox.IsEnabled = false;

        }
    }
}