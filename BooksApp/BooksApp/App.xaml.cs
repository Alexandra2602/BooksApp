using BooksApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation { get; internal set; }
       
        public App()
        {
            InitializeComponent();

            this.MainPage = new NavigationPage(new LoginPage());
        }
      
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
       
    }
}
