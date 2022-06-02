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
        User ul;
        Book bl;
        public ReviewDetailsPage(User ulist, Book blist)
        {
            InitializeComponent();
            ul = ulist;
            bl = blist;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            toolbaritem.Text = "Logged in as " + ul.Name ;
            var shopl = (Book)BindingContext;
            //var user1 = (User)BindingContext;
            finishedListView.ItemsSource = await App.Database.GetListFinishedBooksAsync(shopl.ID);
            reviewlistView.ItemsSource = await App.Database.GetListReviewsAsync(shopl.ID);
            ratingListView.ItemsSource = await App.Database.GetListRatingsAsync(shopl.ID);
            if( shopl.Average_Rating ==5)
            {
                star1.IsVisible = true;
                star2.IsVisible = true;
                star3.IsVisible = true;
                star4.IsVisible = true;
                star5.IsVisible = true;
            }
            if (shopl.Average_Rating < 5 && shopl.Average_Rating >=4)
            {
                star2.IsVisible = true;
                star3.IsVisible = true;
                star4.IsVisible = true;
                star5.IsVisible = true;
            }
            if (shopl.Average_Rating < 4 && shopl.Average_Rating >=3)
            {
                star3.IsVisible = true;
                star4.IsVisible = true;
                star5.IsVisible = true;
            }
            if (shopl.Average_Rating < 3 && shopl.Average_Rating >=2)
            {
                star4.IsVisible = true;
                star5.IsVisible = true;
            }
            if (shopl.Average_Rating < 1 && shopl.Average_Rating >=1)
            {
                star5.IsVisible = true;
            }
            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            reviewlistView.IsVisible = true;
            reviewbutton.BackgroundColor = Color.Ivory;
            reviewbutton.TextColor = Color.FromHex("#855438");
            ratingbutton.BackgroundColor = Color.FromHex("#855438");
            ratingbutton.TextColor = Color.Ivory;
            feedbutton.BackgroundColor = Color.FromHex("#855438");
            feedbutton.TextColor = Color.Ivory;
            ratingListView.IsVisible = false;
            finishedListView.IsVisible = false;
        }
        private void Button2_Clicked(object sender, EventArgs e)
        {
            ratingListView.IsVisible = true;
            ratingbutton.BackgroundColor = Color.Ivory;
            ratingbutton.TextColor = Color.FromHex("#855438");
            reviewbutton.BackgroundColor = Color.FromHex("#855438");
            reviewbutton.TextColor = Color.Ivory;
            feedbutton.BackgroundColor = Color.FromHex("#855438");
            feedbutton.TextColor = Color.Ivory;
            reviewlistView.IsVisible = false;
            finishedListView.IsVisible = false;
        }
        private void Button3_Clicked(object sender, EventArgs e)
        {
            finishedListView.IsVisible = true;
            feedbutton.BackgroundColor = Color.Ivory;
            feedbutton.TextColor = Color.FromHex("#855438");
            reviewbutton.BackgroundColor = Color.FromHex("#855438");
            reviewbutton.TextColor = Color.Ivory;
            ratingbutton.BackgroundColor = Color.FromHex("#855438");
            ratingbutton.TextColor = Color.Ivory;
            reviewlistView.IsVisible = false;
            ratingListView.IsVisible = false;
        }
    }
}