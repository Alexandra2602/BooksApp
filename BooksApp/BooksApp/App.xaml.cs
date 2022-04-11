using BooksApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp
{
    public partial class App : Application
    {
        public static string FilePath = string.Empty;
       
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }
        public App(string filePath)
        {
            InitializeComponent();
            FilePath = filePath;
            MainPage = new NavigationPage(new LoginPage());

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
