using BooksApp.Models;
using System;
using System.Collections.Generic;
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
            float media = bl.Average_Rating;
            float nr = bl.Number;
            float sum = bl.Total;
            var rating = (RatingModel)BindingContext;
            RatingModel r;
            if (rating != null)
            {
                nr = nr + 1;
                sum = sum + rating.Description;
                if(nr!=0)
                {
                    media = sum / nr;
                    bl.Number = nr;
                    bl.Total = sum;
                    bl.Average_Rating = media;
                    await App.Database.SaveBookListAsync(bl);
                }
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