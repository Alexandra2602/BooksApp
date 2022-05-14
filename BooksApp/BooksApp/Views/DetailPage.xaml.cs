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
        public DetailPage(User ulist)
        {
            InitializeComponent();
            ul = ulist;

        }
        protected override async void OnAppearing()
        {
            label1.Text = ul.Name;
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewPage((Book)
           this.BindingContext)
            {
                BindingContext = new Review()
            });

        }
        async void OnChooseButtonClicked2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RatingPage((Book)
           this.BindingContext)
            {
                BindingContext = new RatingModel()
            });

        }
    }
}