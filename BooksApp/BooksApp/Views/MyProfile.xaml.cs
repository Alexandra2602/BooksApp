using BooksApp.Models;
using BooksApp.ViewModels;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MyProfile : ContentPage
    {
        private ObservableCollection<Book> myrootobject;
        public MyProfile()
        {
            InitializeComponent();
            BindingContext = new PickerViewModel();
            var assembly = typeof(BooksPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("BooksApp.books.json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                List<Book> mylist = JsonConvert.DeserializeObject<List<Book>>(json);
                myrootobject = new ObservableCollection<Book>(mylist);
                MyList.ItemsSource = myrootobject;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            popupView2.IsVisible = true;

        }
        private void TapGestureRecognizer2_Tapped(object sender, EventArgs e)
        {
            popupView2.IsVisible = true;

        }
        private void TapGestureRecognizer3_Tapped(object sender, EventArgs e)
        {
            popupView2.IsVisible = true;

        }
        void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }
        void OnEditorCompleted(object sender, EventArgs e)
        {
            string text = ((Editor)sender).Text;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            MainLabel.Text = Slider.Value.ToString();
        }
        readonly SQLiteAsyncConnection database;
        private async void Image_Clicked(object sender, EventArgs e)
        {
            await PickerPhotoAsync();
        }
        string PhotoPath = null;
        async Task PickerPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }
        async Task LoadPhotoAsync(FileResult photo)
        {
            //canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;

            }
            //save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (Stream stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
            {
                await stream.CopyToAsync(newStream);

            }
            PhotoPath = newFile;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            if(PhotoPath!=null)
            {
                var user = new User();
                user.ImagePath = PhotoPath;
                //SaveNoteAsync(user);
            }

        }
    }

}
