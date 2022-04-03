using BooksApp.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

        private void Handle_Clicked(object sender, EventArgs e)
        {
            var item = new RegUserTable()
            {
                Name = nameEntry.Text,
                LastName = lastnameEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text,
                PhoneNumber = phonenumberEntry.Text,
                Address = addressEntry.Text
            };
            if (nameEntry.Text != null & lastnameEntry.Text != null & emailEntry.Text != null & passwordEntry.Text != null & phonenumberEntry.Text != null & addressEntry.Text != null)
            {
                var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
                var db = new SQLiteConnection(dbpath);
                db.CreateTable<RegUserTable>();

                db.Insert(item);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Congratulation", "You have successfully registered", "ok","cancel");

                    if (result)
                    {
                        await Navigation.PushAsync(new LoginPage());
                    }
                });
            }
            else Device.BeginInvokeOnMainThread(async () =>
            {
                await this.DisplayAlert("Error", "You have to complet all the fields", "Yes", "Cancel");

            });



        }
    
}
}