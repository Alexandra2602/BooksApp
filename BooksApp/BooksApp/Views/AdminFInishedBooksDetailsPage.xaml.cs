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
    public partial class AdminFInishedBooksDetailsPage : ContentPage
    {
        public AdminFInishedBooksDetailsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Book)BindingContext;

            finishedListView.ItemsSource = await App.Database.GetListFinishedBooksAsync(shopl.ID);
        }
        async void finishedListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AdminEditFinished
                {
                    BindingContext = e.SelectedItem as FinishedBook
                });
            }

        }
 

    
    }
}