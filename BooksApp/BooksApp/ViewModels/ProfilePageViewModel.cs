using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BooksApp.ViewModels
{
    class ProfilePageViewModel
    {
        public IList<Genre> GenreList { get; set; }
        public ProfilePageViewModel()
        {
            try
            {
                GenreList = new ObservableCollection<Genre>();
                GenreList.Add(new Genre { GenreId = 1, GenreName = "Biography" });
                GenreList.Add(new Genre { GenreId = 2, GenreName = "Business" });
                GenreList.Add(new Genre { GenreId = 3, GenreName = "Classics" });
                GenreList.Add(new Genre { GenreId = 4, GenreName = "Fantasy" });
                GenreList.Add(new Genre { GenreId = 5, GenreName = "Fiction" });
                GenreList.Add(new Genre { GenreId = 6, GenreName = "Financial Education" });
                GenreList.Add(new Genre { GenreId = 7, GenreName = "History" });
                GenreList.Add(new Genre { GenreId = 8, GenreName = "Horror" });
                GenreList.Add(new Genre { GenreId = 9, GenreName = "Humor" });
                GenreList.Add(new Genre { GenreId = 10, GenreName = "Mystery" });
                GenreList.Add(new Genre { GenreId = 11, GenreName = "Philosophy" });
                GenreList.Add(new Genre { GenreId = 12, GenreName = "Psychology" });
                GenreList.Add(new Genre { GenreId = 13, GenreName = "Romance" });
                GenreList.Add(new Genre { GenreId = 14, GenreName = "Science Fiction" });
                GenreList.Add(new Genre { GenreId = 15, GenreName = "Self-Development" });
                GenreList.Add(new Genre { GenreId = 16, GenreName = "Spirituality" });
                GenreList.Add(new Genre { GenreId = 17, GenreName ="Thriller" });
                GenreList.Add(new Genre { GenreId = 18, GenreName = "Young Adult" });
            }
            catch (Exception ex)
            {

            }
        }

    }
}
