﻿using BooksApp.Models;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
       public void RegisterButton_Clicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name = nameEntry.Text,
                LastName = lastnameEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text,
                PhoneNumber = phonenumberEntry.Text,
                Address = addressEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                if (nameEntry.Text != null & lastnameEntry.Text != null & emailEntry.Text != null & passwordEntry.Text != null & phonenumberEntry.Text != null & addressEntry.Text != null)
                {
                    conn.CreateTable<User>();
                    int rowsAdded = conn.Insert(user);       
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await this.DisplayAlert("Congratulation", "You have successfully registered", "Yes", "Cancel");

                        if (result)
                        {
                            await Navigation.PushAsync(new LoginPage());
                        }
                    });
                }
                else Device.BeginInvokeOnMainThread(async () =>
                {
                    await this.DisplayAlert("Error", "You have to complete all the fields", "Yes", "Cancel");

                });
            }
        }
    }
}
