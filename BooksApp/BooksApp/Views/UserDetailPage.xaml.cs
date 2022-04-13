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
    public partial class UserDetailPage : ContentPage
    {
        User selectedUser;
        public UserDetailPage(User selectedUser)
        {
            InitializeComponent();
            this.selectedUser = selectedUser;
            nameEntry.Text = selectedUser.Name;
        }

        void Update_Clicked(object sender, System.EventArgs e)
        {
            selectedUser.Name = nameEntry.Text;
            using (SQLiteConnection conn= new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                int rowsAdded = conn.Update(selectedUser);
                if (rowsAdded > 0)
                    DisplayAlert("Succes", "User succesfull updated", "Ok");
                else
                    DisplayAlert("Error", "User not succesfull updated", "Ok");

            }
        }
        void Delete_Clicked(object sender, System.EventArgs e)
        {
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