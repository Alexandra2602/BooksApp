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
            public CalendarPage()
            {
                InitializeComponent();

            }
            protected override async void OnAppearing()
            {
                base.OnAppearing();
                listView.ItemsSource = await App.Database.GetBookListsAsync();
            }
            private void OnDateSelected(object sender, DateChangedEventArgs e)
            {
                Recalculate();
            }

            private void includeSwitch_Toggled(object sender, ToggledEventArgs e)
            {
                Recalculate();
            }
            void Recalculate()
            {
                TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date + (includeSwitch.IsToggled ? TimeSpan.FromDays(1) : TimeSpan.Zero);
                resultLabel.Text = String.Format("You finished the book in {0} day{1}", timeSpan.Days, timeSpan.Days == 1 ? "" : "s");

            }

            private void Button_Clicked(object sender, EventArgs e)
            {
                listView.IsVisible = true;

            }

            async void Top_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new TopPage());
            }
            async void Home_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new BooksPage(ul));
            }
           
            async void Calendar_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new CalendarPage());
            }
            async void Profile_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new ProfilePage());
            }
            async void Members_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new UsersPage());
            }

        }
    }
