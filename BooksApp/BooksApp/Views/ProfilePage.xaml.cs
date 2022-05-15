using BooksApp.Models;
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
            imgpathentry.Text = ul.ImagePath2;
            imgpathbook1.Text = ul.FavoriteBook1;
            imgpathbook2.Text = ul.FavoriteBook2;
            imgpathbook3.Text = ul.FavoriteBook3;
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
        string ImagePath2;
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
                ImagePath2 = result.FullPath;
                imgpathentry.Text = ImagePath2;
                ul.ImagePath2 = imgpathentry.Text;
                resultImage.Source = ul.ImagePath2;
            }
        }
        void Button_Clicked_1(object sender, EventArgs e)
        {
            ul.ImagePath2 = imgpathentry.Text;
            ul.Description = Description.Text;
            resultImage.Source = ul.ImagePath2;
            ul.FavoriteGenre1 = (string)FirstPicker.SelectedItem.ToString();
            ul.FavoriteGenre2 = (string)SecondPicker.SelectedItem.ToString();
            ul.FavoriteGenre3 = (string)ThirdPicker.SelectedItem.ToString();
            ul.FavoriteBook1 = imgpathbook1.Text;
            ul.FavoriteBook2 = imgpathbook2.Text;
            ul.FavoriteBook3 = imgpathbook3.Text;
            book1.Source = ul.FavoriteBook1;
            book2.Source = ul.FavoriteBook2;
            book3.Source = ul.FavoriteBook3;


            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                int rowsAdded = conn.Update(ul);
                if (rowsAdded > 0)
                {
                    DisplayAlert("Succes", "User succesfull updated", "Ok");
                    
                }
                else
                    DisplayAlert("Error", "User not succesfull updated", "Ok");
            }

        }
        protected override  void OnAppearing()
        {
            base.OnAppearing();
            label1.Text = ul.Name;
            resultImage.Source = ul.ImagePath2;
            cityEntry.Text = ul.Address;
            Description.Text = ul.Description;
            FirstPicker.SelectedItem = ul.FavoriteGenre1;
            SecondPicker.SelectedItem = ul.FavoriteGenre2;
            ThirdPicker.SelectedItem = ul.FavoriteGenre3;
            book1.Source = ul.FavoriteBook1;
            book2.Source = ul.FavoriteBook2;
            book3.Source = ul.FavoriteBook3;

        }
        string FavoriteBook1;
        string FavoriteBook2;
        string FavoriteBook3;
        async void fav_book1_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                book1.Source = ImageSource.FromStream(() => stream);
                FavoriteBook1 = result.FullPath;
                imgpathbook1.Text = FavoriteBook1;
                ul.FavoriteBook1 = imgpathbook1.Text;
                book1.Source = ul.FavoriteBook1; 
            }
        }
        async void fav_book2_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                book2.Source = ImageSource.FromStream(() => stream);
                FavoriteBook2 = result.FullPath;
                imgpathbook2.Text = FavoriteBook2;
                ul.FavoriteBook2 = imgpathbook2.Text;
                book2.Source = ul.FavoriteBook2;
            }
        }
        async void fav_book3_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                book3.Source = ImageSource.FromStream(() => stream);
                FavoriteBook3 = result.FullPath;
                imgpathbook3.Text = FavoriteBook3;
                ul.FavoriteBook3 = imgpathbook3.Text;
                book3.Source = ul.FavoriteBook3;
            }
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

        async void Button_Clicked_2(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new LoginPage());
        }
    }
    }

