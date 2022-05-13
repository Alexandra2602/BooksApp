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
    public partial class AdminEditMembersPage : ContentPage
    {
        public AdminEditMembersPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var ulist = (User)BindingContext;
           // await App.Database.SaveUserListAsync(ulist);
            await Navigation.PushAsync(new AdminMembersPage());
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var ulist = (User)BindingContext;
           // await App.Database.DeleteUserListAsync(ulist);
            await Navigation.PushAsync(new AdminMembersPage());

        }
    }
}