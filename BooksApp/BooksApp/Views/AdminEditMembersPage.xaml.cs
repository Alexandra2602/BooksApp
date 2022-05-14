﻿using BooksApp.Models;
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
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //var ulist = (User)BindingContext;
            // await App.Database.SaveUserListAsync(ulist);
            //await Navigation.PushAsync(new AdminMembersPage());
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
                    DisplayAlert("Succes", "User succesfull updated", "Ok");
                else
                    DisplayAlert("Error", "User not succesfull updated", "Ok");
            }
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            //var ulist = (User)BindingContext;
            // await App.Database.DeleteUserListAsync(ulist);
            //await Navigation.PushAsync(new AdminMembersPage());
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                int rowsAdded = conn.Delete(selectedUser);
                if (rowsAdded > 0)
                    DisplayAlert("Succes", "User succesfull deleted", "Ok");
                else
                    DisplayAlert("Error", "User not succesfull deleted", "Ok");

            }

        }
    }
}