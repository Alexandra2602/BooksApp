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
    public partial class AdminRatingDetailsPage : ContentPage
    {
        public AdminRatingDetailsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Book)BindingContext;

            ratinglistView.ItemsSource = await App.Database.GetListRatingsAsync(shopl.ID);
        }

        async void ratinglistView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AdminEditRatings
                {
                    BindingContext = e.SelectedItem as RatingModel
                });
            }

        }
    }
}