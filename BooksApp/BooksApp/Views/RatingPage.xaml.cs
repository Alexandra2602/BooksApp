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
        public RatingPage(Book blist)
        {

            InitializeComponent();
            bl = blist;
            
        }
        int nr = 0;
        int sum=0;
        int medie=0;
       
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            bl.Average_Rating = 0;
            var rating = (RatingModel)BindingContext;
            await App.Database.SaveRatingAsync(rating);
            listView2.ItemsSource = await App.Database.GetRatingsAsync();
            RatingModel r;
            if (rating != null)
            {
                r = rating as RatingModel;
                var lp = new ListRating()
                {
                    BookID = bl.ID,
                    RatingID = r.ID
                };
               await App.Database.SaveListRatingAsync(lp);
                    r.ListRatings = new List<ListRating> { lp };
                    await Navigation.PopAsync();
                
               
            }
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView2.ItemsSource = await App.Database.GetRatingsAsync();
        }



    }
}