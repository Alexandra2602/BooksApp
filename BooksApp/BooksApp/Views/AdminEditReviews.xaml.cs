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
    public partial class AdminEditReviews : ContentPage
    {
        
        public AdminEditReviews()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var review1 = (Review)BindingContext;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var rlist = (Review)BindingContext;
            await App.Database.SaveReviewAsync(rlist);
            await Navigation.PopAsync();
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            var rlist = (Review)BindingContext;
            await App.Database.DeleteReviewAsync(rlist);
            await Navigation.PopAsync();

        }
    }
}