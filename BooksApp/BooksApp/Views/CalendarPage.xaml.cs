using BooksApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        User ul;
        public CalendarPage(User ulist)
        {
            InitializeComponent();
            ul = ulist;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            toolbaritem.Text = "Logged in as " + ul.Name;
           
        }
         async void Top_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TopPage(ul));
        }
        async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksPage(ul));
        }
        async void Calendar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalendarPage(ul));
        }
        async void Profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(ul));
        }
        async void Members_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsersPage(ul));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            january.IsVisible = false;
            february.IsVisible = true;
            book1.IsVisible = false;
            book2.IsVisible = false;
            book3.IsVisible = false;
            book4.IsVisible = true;
            book5.IsVisible = true;
            book6.IsVisible = true;
        }
        private void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            february.IsVisible = false;
            january.IsVisible = true;
            book4.IsVisible = false;
            book5.IsVisible = false;
            book6.IsVisible = false;
            book1.IsVisible = true;
            book2.IsVisible = true;
            book3.IsVisible = true;
            
        }
        private void TapGestureRecognizer_Tapped3(object sender, EventArgs e)
        {
            february.IsVisible = false;
            march.IsVisible = true;
            book4.IsVisible = false;
            book5.IsVisible = false;
            book6.IsVisible = false;
            book7.IsVisible = true;
            book8.IsVisible = true;
            book9.IsVisible = true;
        }
        private void TapGestureRecognizer_Tapped4(object sender, EventArgs e)
        {
            march.IsVisible = false;
            february.IsVisible = true;
            book7.IsVisible = false;
            book8.IsVisible = false;
            book9.IsVisible = false;
            book4.IsVisible = true;
            book5.IsVisible = true;
            book6.IsVisible = true;


        }
        private void TapGestureRecognizer_Tapped5(object sender, EventArgs e)
        {
            march.IsVisible = false;
            april.IsVisible = true;
            book7.IsVisible = false;
            book8.IsVisible = false;
            book9.IsVisible = false;
            book10.IsVisible = true;
            book11.IsVisible = true;
            book12.IsVisible = true;
        }
        private void TapGestureRecognizer_Tapped6(object sender, EventArgs e)
        {
            april.IsVisible = false;
            march.IsVisible = true;
            book10.IsVisible = false;
            book11.IsVisible = false;
            book12.IsVisible = false;
            book7.IsVisible = true;
            book8.IsVisible = true;
            book9.IsVisible = true;
        }
        private void TapGestureRecognizer_Tapped7(object sender, EventArgs e)
        {
            april.IsVisible = false;
            may.IsVisible = true;
            book10.IsVisible = false;
            book11.IsVisible = false;
            book12.IsVisible = false;
            book13.IsVisible = true;
            book14.IsVisible = true;
            book15.IsVisible = true;
        }
        private void TapGestureRecognizer_Tapped8(object sender, EventArgs e)
        {
            may.IsVisible = false;
            april.IsVisible = true;
            book13.IsVisible = false;
            book14.IsVisible = false;
            book15.IsVisible = false;
            book10.IsVisible = true;
            book11.IsVisible = true;
            book12.IsVisible = true;
        }
        private void TapGestureRecognizer_Tapped9(object sender, EventArgs e)
        {
            may.IsVisible = false;
            june.IsVisible = true;
            book13.IsVisible = false;
            book14.IsVisible = false;
            book15.IsVisible = false;
            book16.IsVisible = true;
            book17.IsVisible = true;
            book18.IsVisible = true;
        }
        private void TapGestureRecognizer_Tapped10(object sender, EventArgs e)
        {
            june.IsVisible = false;
            may.IsVisible = true;
            book16.IsVisible = false;
            book17.IsVisible = false;
            book18.IsVisible = false;
            book13.IsVisible = true;
            book14.IsVisible = true;
            book15.IsVisible = true;
        }

     

        async void Button_Clicked(object sender, EventArgs e)
        {
            booklistView.IsVisible = true;
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
