using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.ViewModels
{
    public class MainViewModel
    {


        #region Singleton
        private static MainViewModel instance;
        
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion

    }
}
