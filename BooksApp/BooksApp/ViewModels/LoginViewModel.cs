using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        
        private string email;
        private string password;
        private bool isEnabled;
        
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        public bool IsRemembered
        {
            get;
            set;
        }

    }
}