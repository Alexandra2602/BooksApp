using BooksApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminRatingDetailsPage : ContentPage
    {
        Book bl;
        
        public AdminRatingDetailsPage(Book blist)
        {
            InitializeComponent();
            bl = blist;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Book)BindingContext;
            ratingListView.ItemsSource = await App.Database.GetListRatingsAsync(shopl.ID);
        }
        async void ratinglistView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AdminEditRatings(bl)
                {
                    BindingContext = e.SelectedItem as RatingModel
                });
            }

        }
    }
}