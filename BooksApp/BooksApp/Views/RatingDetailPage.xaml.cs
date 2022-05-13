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
        public partial class RatingDetailPage : ContentPage
        {
            public RatingDetailPage()
            {
                InitializeComponent();
            }
            protected override async void OnAppearing()
            {
                base.OnAppearing();
                var shopl = (Book)BindingContext;
                ratingListView.ItemsSource = await App.Database.GetListRatingsAsync(shopl.ID);
            }
        }
    }