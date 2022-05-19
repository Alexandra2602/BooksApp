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
    public partial class ReviewPage : ContentPage
    {
        Book bl;
        User ul;
        public ReviewPage(User ulist, Book blist)
        {
            InitializeComponent();
            bl = blist;
            ul = ulist;
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetReviewsAsync(); 
            toolbaritem.Text = "Logged in as " + ul.Name;
            user_name.Text=ul.Name;
        }
     
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            
            var review = (Review)BindingContext;
            await App.Database.SaveReviewAsync(review);
            listView.ItemsSource = await App.Database.GetReviewsAsync();
            Review r;
            if (review != null)
            {
                r = review as Review;
                r.UserName = user_name.Text;
                await App.Database.SaveReviewAsync(r);
                var lp = new ListReview()
                {
                    BookID = bl.ID,
                    ReviewID = r.ID,
                    UserID=ul.Id
                };
                
                await App.Database.SaveListReviewAsync(lp);
                r.ListReviews = new List<ListReview> { lp };
                
                await Navigation.PopAsync();

            }
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var review = (Review)BindingContext;
            await App.Database.DeleteReviewAsync(review);
            listView.ItemsSource = await App.Database.GetReviewsAsync();
        }
       

    }
}