using BooksApp.Models;
using BooksApp.Services;
using BooksApp.Views;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;


namespace BooksApp.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Book> myrootobject;
        private bool isRefreshing;
        private string filter;
        private List<Book> bookslist;


        #endregion


    }
}













