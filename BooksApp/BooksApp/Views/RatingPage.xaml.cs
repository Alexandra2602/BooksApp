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
    public partial class RatingPage : ContentPage
    {
        Book bl;
        User ul;
        public RatingPage(User ulist, Book blist)
        {
            InitializeComponent();
            bl = blist;
            ul = ulist;    
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ratingListView.ItemsSource = await App.Database.GetRatingsAsync();
            toolbaritem.Text = "Logged in as " + ul.Name;
            user_name.Text = ul.Name;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            bl.Average_Rating = 0;
            var rating = (RatingModel)BindingContext;
            await App.Database.SaveRatingAsync(rating);
            ratingListView.ItemsSource = await App.Database.GetRatingsAsync();
            RatingModel r;
            if (rating != null)
            {
                r = rating as RatingModel;
                r.UserName = user_name.Text;
                await App.Database.SaveRatingAsync(r);
                var lp = new ListRating()
                {
                    BookID = bl.ID,
                    RatingID = r.ID,
                    UserID=ul.Id
                };
                await App.Database.SaveListRatingAsync(lp);
                r.ListRatings = new List<ListRating> { lp };
                await Navigation.PopAsync(); 
            }
        }
    }
}