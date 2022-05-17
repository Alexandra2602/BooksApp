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
        protected override void OnAppearing()
        {
            toolbaritem.Text = "Logged in as " + ul.Name;
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
        async void Read_Clicked(object sender, EventArgs e)
        {
            button_read.BackgroundColor=Color.FromHex("#855438");
            button_read.TextColor = Color.Ivory;

        }
        async void Reading_Clicked(object sender, EventArgs e)
        {

        }
        async void Dropped_Clicked(object sender, EventArgs e)
        {

        }

    }
}