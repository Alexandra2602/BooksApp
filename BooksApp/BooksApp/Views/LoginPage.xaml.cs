using BooksApp.Models;
using BooksApp.Tables;
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
            EntryUser.Text = Preferences.Get("RandomText", string.Empty);
            EntryPassword.Text = Preferences.Get("RandomText", string.Empty);
            RandomSwitch.IsToggled = Preferences.Get("RandomSwitch", false);
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

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
        async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        void Remember_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("RandomText", EntryUser.Text);
            Preferences.Set("RandomText", EntryPassword.Text);
            Preferences.Set("RandomSwitch", RandomSwitch.IsToggled);

            var button = (Button)sender;
            button.TextColor = Color.Red;
        }
        private void Not_Remember_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            var button = (Button)sender;
            button.TextColor = Color.Red;
        }

    }
}