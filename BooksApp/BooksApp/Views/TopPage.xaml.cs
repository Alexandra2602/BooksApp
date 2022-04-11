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
    public partial class TopPage : ContentPage
    {
        public TopPage()
        {
            InitializeComponent();
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
        async void Members_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MembersPage());
        }

    }
}