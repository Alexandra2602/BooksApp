using BooksApp.Data;
using BooksApp.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp
{
    public partial class App : Application
    {
        public static string FilePath = string.Empty;

        static BookListDatabase database;
        public static BookListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BookListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BooksList.db3"));
                }
                return database;
            }
        }
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
