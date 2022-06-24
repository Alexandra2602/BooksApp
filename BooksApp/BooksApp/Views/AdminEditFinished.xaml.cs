using BooksApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminEditFinished : ContentPage
    {
        public AdminEditFinished()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var finished1 = (FinishedBook)BindingContext;
        }
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            var flist = (FinishedBook)BindingContext;
            await App.Database.DeleteFinishedBookAsync(flist);
            await Navigation.PopAsync();

        }
    }
}