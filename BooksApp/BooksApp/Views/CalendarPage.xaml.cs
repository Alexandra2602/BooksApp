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

        public CalendarPage()
        {
            InitializeComponent();
            BindingContext = this;

            XamForms.Controls.Calendar calendar = new XamForms.Controls.Calendar();

        }
        async void Calendar_DateClicked(Object sender, XamForms.Controls.DateTimeEventArgs e)
        {

            string result = await DisplayPromptAsync("New Book", "Add a book that you finished:");

            if (result == null)
            {
                return;
            }
            var specialDates = calendar.SpecialDates;

            SpecialDate newDate = new SpecialDate(e.DateTime)
            {
                Selectable = true,
                BackgroundPattern = new BackgroundPattern(1)
                {
                    Pattern = new List<Pattern>
                     {
                         new Pattern { WidthPercent = 1f, HightPercent = 0.6f, Color = Color.Transparent },
                         new Pattern{ WidthPercent = 1f, HightPercent = 0.4f, Color = Color.Transparent, Text = result, TextColor=Color.Black, TextSize=11, TextAlign=TextAlign.Middle},
                     }
                }
            };
            specialDates.Add(newDate);

            calendar.SpecialDates = specialDates;
            calendar.ForceRedraw();


        }
        async void Top_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TopPage());
        }
        async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksPage());
        }
        async void New_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewsPage());
        }
        async void Calendar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalendarPage());
        }
        async void Profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }


    }
}