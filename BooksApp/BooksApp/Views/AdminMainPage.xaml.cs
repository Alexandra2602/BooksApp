using BooksApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminMainPage : ContentPage
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetBookListsAsync();
        }
        async void OnBookListAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = new Book()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPage
                {
                    BindingContext = e.SelectedItem as Book
                });
            }
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMembersPage());
        }
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMainPage());  
        }
        async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminRatingPage());
        }
        async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminReviewPage());
        }
        async void Button_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminFinishedBooksPage());
        }
    }
}
