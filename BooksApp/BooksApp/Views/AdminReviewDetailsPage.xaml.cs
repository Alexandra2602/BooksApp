using BooksApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminReviewDetailsPage : ContentPage
    {
        public AdminReviewDetailsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Book)BindingContext;
            reviewlistView.ItemsSource = await App.Database.GetListReviewsAsync(shopl.ID);
        }
        async void reviewlistView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AdminEditReviews
                {
                    BindingContext = e.SelectedItem as Review
                });
            }

        }
    }
}