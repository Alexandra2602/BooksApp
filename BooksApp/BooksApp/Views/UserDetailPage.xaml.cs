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
    public partial class UserDetailPage : ContentPage
    {
        User selectedUser;
        public UserDetailPage(User selectedUser)
        {
            InitializeComponent();
            this.selectedUser = selectedUser;
            nameEntry.Text = selectedUser.Name;
        }

        void Update_Clicked(object sender, System.EventArgs e)
        {
            selectedUser.Name = nameEntry.Text;
        }
        void Delete_Clicked(object sender, System.EventArgs e)
        {
            
        }
    }
}