using BooksApp.Models;
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
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var blist = (Book)BindingContext;
            await App.Database.DeleteBookListAsync(blist);
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Book)BindingContext;
            
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
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (TitleEntry.Text != null && AuthorEntry.Text != null && PublisherEntry.Text != null && YearPublishedEntry.Text != null && NumberOfPagesEntry.Text != null && YearAndMonthEntry.Text != null && imgpathentry.Text != null)
            {
                var blist = (Book)BindingContext;
                await App.Database.SaveBookListAsync(blist);
                await Navigation.PopAsync();
            }
            
                else Device.BeginInvokeOnMainThread(async () =>
                {
                    await this.DisplayAlert("Error", "You have to complet all the fields", "Yes", "Cancel");

                });

        }


    }
}
