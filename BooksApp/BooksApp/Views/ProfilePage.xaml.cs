﻿using BooksApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        User ul;
        public ProfilePage(User ul)
        {
            InitializeComponent();
            this.ul = ul;
            imgpathentry.Text = ul.ImagePath;
            
            //ImagePath = ul.ImagePath;
            FirstPicker.Items.Add("Biography");
            FirstPicker.Items.Add("Business");
            FirstPicker.Items.Add("Classics");
            FirstPicker.Items.Add("Fantasy");
            FirstPicker.Items.Add("Fiction");
            FirstPicker.Items.Add("Financial Education");
            FirstPicker.Items.Add("History");
            FirstPicker.Items.Add("Horror");
            FirstPicker.Items.Add("Humor");
            FirstPicker.Items.Add("Mystery");
            FirstPicker.Items.Add("Philosophy");
            FirstPicker.Items.Add("Romance");
            FirstPicker.Items.Add("Science Fiction");
            FirstPicker.Items.Add("Self-Development");
            FirstPicker.Items.Add("Spirituality");
            FirstPicker.Items.Add("Thriller");
            FirstPicker.Items.Add("Young Adult");

            SecondPicker.Items.Add("Biography");
            SecondPicker.Items.Add("Business");
            SecondPicker.Items.Add("Classics");
            SecondPicker.Items.Add("Fantasy");
            SecondPicker.Items.Add("Fiction");
            SecondPicker.Items.Add("Financial Education");
            SecondPicker.Items.Add("History");
            SecondPicker.Items.Add("Horror");
            SecondPicker.Items.Add("Humor");
            SecondPicker.Items.Add("Mystery");
            SecondPicker.Items.Add("Philosophy");
            SecondPicker.Items.Add("Romance");
            SecondPicker.Items.Add("Science Fiction");
            SecondPicker.Items.Add("Self-Development");
            SecondPicker.Items.Add("Spirituality");
            SecondPicker.Items.Add("Thriller");
            SecondPicker.Items.Add("Young Adult");

            ThirdPicker.Items.Add("Biography");
            ThirdPicker.Items.Add("Business");
            ThirdPicker.Items.Add("Classics");
            SecondPicker.Items.Add("Fantasy");
            ThirdPicker.Items.Add("Fiction");
            ThirdPicker.Items.Add("Financial Education");
            ThirdPicker.Items.Add("History");
            ThirdPicker.Items.Add("Horror");
            ThirdPicker.Items.Add("Humor");
            ThirdPicker.Items.Add("Mystery");
            ThirdPicker.Items.Add("Philosophy");
            ThirdPicker.Items.Add("Romance");
            ThirdPicker.Items.Add("Science Fiction");
            ThirdPicker.Items.Add("Self-Development");
            ThirdPicker.Items.Add("Spirituality");
            ThirdPicker.Items.Add("Thriller");
            ThirdPicker.Items.Add("Young Adult");
         }
        string ImagePath;
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
                ImagePath = result.FullPath;
                imgpathentry.Text = ImagePath;
            }
        }
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            ul.ImagePath = imgpathentry.Text;
            ul.Description = Description.Text;
            ul.FavoriteGenre1 = (string)FirstPicker.SelectedItem.ToString();
            ul.FavoriteGenre2 = (string)SecondPicker.SelectedItem.ToString();
            ul.FavoriteGenre3 = (string)ThirdPicker.SelectedItem.ToString();
            
           
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                int rowsAdded = conn.Update(ul);
                if (rowsAdded > 0)
                    DisplayAlert("Succes", "User succesfull updated", "Ok");
                else
                    DisplayAlert("Error", "User not succesfull updated", "Ok");
            }

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            label1.Text = ul.Name;
            resultImage.Source = ul.ImagePath;
            cityEntry.Text = ul.Address;
            Description.Text = ul.Description;
            FirstPicker.SelectedItem = ul.FavoriteGenre1;
            SecondPicker.SelectedItem = ul.FavoriteGenre2;
            ThirdPicker.SelectedItem = ul.FavoriteGenre3;
            //book1.Source = ul.FavoriteBook1;
            popuplistView.ItemsSource = await App.Database.GetBookListsAsync();
            popup2listView.ItemsSource = await App.Database.GetBookListsAsync();
            popup3listView.ItemsSource = await App.Database.GetBookListsAsync();
        }
        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            popuplistView.IsVisible = true;
        }
        async void popuplistView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ProfilePage(ul)
                {
                    BindingContext = e.SelectedItem as Book
                });
                popuplistView.IsVisible = false;
            }
        }

        async void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            popup2listView.IsVisible = true;

        }
        async void TapGestureRecognizer_Tapped3(object sender, EventArgs e)
        {
            popup3listView.IsVisible = true;

        }
      




        async void Top_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TopPage(ul));
        }
        async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksPage(ul));
        }

        async void Calendar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalendarPage(ul));
        }
        async void Profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(ul));
        }
        async void Members_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsersPage(ul));
        }

       
    }
}
