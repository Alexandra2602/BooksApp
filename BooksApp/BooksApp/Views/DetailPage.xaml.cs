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
    public partial class DetailPage : ContentPage
    {
        User ul;
        Book bl;
        public DetailPage(User ulist, Book blist)
        {
            InitializeComponent();
            ul = ulist;
            bl = blist;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            toolbaritem.Text = "Logged in as " + ul.Name;
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewPage(ul, bl)
            {
                BindingContext = new Review()
            });

        }
        async void OnChooseButtonClicked2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RatingPage(ul, bl)
            {
                BindingContext = new RatingModel()
            });
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FinishedBookPage(ul, bl)
            {
                BindingContext = new FinishedBook()
            });
        }
    }
}