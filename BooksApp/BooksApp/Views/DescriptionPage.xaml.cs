using BooksApp.Models;
using SQLite;
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
    public partial class DescriptionPage : ContentPage
    {
        User user;
        public DescriptionPage(User user)
        {
            InitializeComponent();
            this.user = user;
            DescriptionEditor.Text = user.Description;
        }
        void Edit_Tapped(object sender, System.EventArgs e)
        {
           user.Description = DescriptionEditor.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                int rowsAdded = conn.Update(user);
                if (rowsAdded > 0)
                    DisplayAlert("Succes", "User succesfull updated", "Ok");
                else
                    DisplayAlert("Error", "User not succesfull updated", "Ok");

            }
        }
        void Save_Tapped(object sender, System.EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                int rowsAdded = conn.Delete(user);
                if (rowsAdded > 0)
                    DisplayAlert("Succes", "User succesfull deleted", "Ok");
                else
                    DisplayAlert("Error", "User not succesfull deleted", "Ok");

            }
        }
    }
}
