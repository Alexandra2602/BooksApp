using BooksApp.Models;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminEditMembersPage : ContentPage
    {
        User selectedUser;
        public AdminEditMembersPage(User selectedUser)
        {
            InitializeComponent();
            this.selectedUser = selectedUser;
            nameEntry.Text = selectedUser.Name;
            lastnameEntry.Text = selectedUser.LastName;
            emailEntry.Text = selectedUser.Email;
            passwordEntry.Text = selectedUser.Password;
            phonenumberEntry.Text = selectedUser.PhoneNumber;
            addressEntry.Text = selectedUser.Address;
        }
        public void OnSaveButtonClicked(object sender, EventArgs e)
        {
            selectedUser.Name = nameEntry.Text;
            selectedUser.LastName = lastnameEntry.Text;
            selectedUser.Email = emailEntry.Text;
            selectedUser.Password = passwordEntry.Text;
            selectedUser.PhoneNumber = phonenumberEntry.Text;
            selectedUser.Address = addressEntry.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                int rowsAdded = conn.Update(selectedUser);
                if (rowsAdded > 0)
                {
                    DisplayAlert("Succes", "User succesfull updated", "Ok");
                    Navigation.PushAsync(new AdminMembersPage());
                }
                else
                {
                    DisplayAlert("Error", "User not succesfull updated", "Ok");
                }
            }
        }
        public void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                int rowsAdded = conn.Delete(selectedUser);
                if (rowsAdded > 0)
                {
                    DisplayAlert("Succes", "User succesfull deleted", "Ok");
                    Navigation.PushAsync(new AdminMembersPage());
                }
                else
                
                    DisplayAlert("Error", "User not succesfull deleted", "Ok");

            }
        }
    }
}