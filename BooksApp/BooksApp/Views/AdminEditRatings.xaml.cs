﻿using BooksApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminEditRatings : ContentPage
    {
        Book bl;
        public AdminEditRatings(Book blist)
        {
            InitializeComponent();
            bl = blist;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var rating1 = (RatingModel)BindingContext;
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            var rlist = (RatingModel)BindingContext;
            
            await App.Database.SaveRatingAsync(rlist);
            await Navigation.PopAsync();
        }
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            var rlist = (RatingModel)BindingContext;
            await App.Database.DeleteRatingAsync(rlist);
            await Navigation.PopAsync();
        }
    }
}