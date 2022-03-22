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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        string imagePath;
        async void Image_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
            }
        }
        async void Image2_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
                imagePath = result.FullPath;
            }
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                RegUserTable user = new RegUserTable()
                {
                    imagePath = imagePath
                };


                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<RegUserTable>();
                    int rows = conn.Insert(user);


                    if (rows > 0)
                        DisplayAlert("Uspjesno", "Oglas Predan", "OK");
                    else
                        DisplayAlert("Neuspjesno", "Oglas nije predan", "OK");
                }

            }
            catch (NullReferenceException nre)
            {

            }
            catch (Exception ex)
            {

            }
        }

                async void Top_Clicked(object sender, EventArgs e)
                {
                    await Navigation.PushAsync(new TopPage());
                }
                async void Home_Clicked(object sender, EventArgs e)
                {
                    await Navigation.PushAsync(new BooksPage());
                }
                async void New_Clicked(object sender, EventArgs e)
                {
                    await Navigation.PushAsync(new NewsPage());
                }
                async void Calendar_Clicked(object sender, EventArgs e)
                {
                    await Navigation.PushAsync(new CalendarPage());
                }
                async void Profile_Clicked(object sender, EventArgs e)
                {
                    await Navigation.PushAsync(new ProfilePage());
                }


            }

      
    }
    