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
    public partial class MembersPage : ContentPage
    {

        public MembersPage()
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
                usersListView.ItemsSource = users;
            }
        }

         public void usersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedUser = usersListView.SelectedItem as User;
            if (selectedUser !=null)
            {
                Navigation.PushAsync(new UserDetailPage(selectedUser));
            }
        }
    }
}