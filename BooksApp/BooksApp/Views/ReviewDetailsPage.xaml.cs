using BooksApp.Models;
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
    public partial class ReviewDetailsPage : ContentPage
    {
        public ReviewDetailsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Book)BindingContext;

            reviewlistView.ItemsSource = await App.Database.GetListReviewsAsync(shopl.ID);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            reviewlistView.IsVisible = true;
            reviewbutton.BackgroundColor = Color.Ivory;
            reviewbutton.TextColor = Color.FromHex("#855438");
            feedbutton.BackgroundColor = Color.FromHex("#855438");
            feedbutton.TextColor = Color.Ivory;
            ratingbutton.BackgroundColor = Color.FromHex("#855438");
            ratingbutton.TextColor = Color.Ivory;

        }
        private void Button2_Clicked(object sender, EventArgs e)
        {

            ratingbutton.BackgroundColor = Color.Ivory;
            ratingbutton.TextColor = Color.FromHex("#855438");
            reviewbutton.BackgroundColor = Color.FromHex("#855438");
            reviewbutton.TextColor = Color.Ivory;
            feedbutton.BackgroundColor = Color.FromHex("#855438");
            feedbutton.TextColor = Color.Ivory;
            reviewlistView.IsVisible = false;

        }
        private void Button3_Clicked(object sender, EventArgs e)
        {

            feedbutton.BackgroundColor = Color.Ivory;
            feedbutton.TextColor = Color.FromHex("#855438");
            reviewbutton.BackgroundColor = Color.FromHex("#855438");
            reviewbutton.TextColor = Color.Ivory;
            ratingbutton.BackgroundColor = Color.FromHex("#855438");
            ratingbutton.TextColor = Color.Ivory;
            reviewlistView.IsVisible = false;

        }
    }
}