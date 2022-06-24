using BooksApp.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinishedBookPage : ContentPage
    {
        User ul;
        Book bl;
        public FinishedBookPage(User ulist, Book blist)
        {
            InitializeComponent();
            bl = blist;
            ul = ulist;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetFinishedBooksAsync();
            toolbaritem.Text = "Logged in as " + ul.Name;
            user_name.Text = ul.Name;
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            int count = ul.Number_of_books;
            var finishedbook = (FinishedBook)BindingContext;
            FinishedBook f;
            if (finishedbook != null)
            {
                f = finishedbook as FinishedBook;
                f.UserName = user_name.Text;
                await App.Database.SaveFinishedBookAsync(f);
                if (finishedbook.UserName == ul.Name)
                {
                    count = count + 1;
                }
                if (count != 0)
                {
                    ul.Number_of_books = count;
                    await App.Database.SaveUserListAsync(ul);
                }
                var lp = new ListFinishedBook()
                {
                    BookID = bl.ID,
                    FinishedID = f.ID,
                    UserID = ul.Id
                };
                await App.Database.SaveListFinishedBookAsync(lp);
                f.ListFinishedBooks = new List<ListFinishedBook> { lp };
                await Navigation.PopAsync();
            }
        }
        async void Button2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
