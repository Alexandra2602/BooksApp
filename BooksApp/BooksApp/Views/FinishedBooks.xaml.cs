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
    public partial class FinishedBooks : ContentPage
    {
        User ul;
        Book bl;
        public FinishedBooks(User ulist,Book blist)
        {
            InitializeComponent();
            ul = ulist;
            bl = blist;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetFinishedAsync();
            toolbaritem.Text = "Logged in as" + ul.Name;
            user_name.Text = ul.Name;
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            var finished = (Finished)BindingContext;
            await App.Database.SaveFinishedAsync(finished);
            listView.ItemsSource = await App.Database.GetFinishedAsync();
            Finished f;
            if (finished != null)
            {
                f = finished as Finished;
                f.UserName = user_name.Text;
                await App.Database.SaveFinishedAsync(f);
                var lp = new ListFinished()
                {
                    BookID = bl.ID,
                    FinishedID = f.ID,
                    UserID = ul.Id
                };

                await App.Database.SaveListFinishedAsync(lp);
                f.ListFinisheds = new List<ListFinished> { lp };

                await Navigation.PopAsync();


                   
                }
        }
    }

}