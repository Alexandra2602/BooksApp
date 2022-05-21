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
    public partial class FinishedBooksDetails : ContentPage
    {
        User ul;
        public FinishedBooksDetails(User ulist)
        {
            InitializeComponent();
            ul = ulist;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var user = (User)BindingContext;
            finishedlistView.ItemsSource = await App.Database.GetListFinishedsAsync(user.Id);
        }
    }
}