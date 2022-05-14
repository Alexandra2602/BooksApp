using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string Description { get; set; }
        public string ImagePath2 { get; set; }

        public string FavoriteGenre1 { get; set; }
        public string FavoriteGenre2 { get; set; }

        public string FavoriteGenre3 { get; set; }

        public string FavoriteBook1 { get; set; }
        public string FavoriteBook2 { get; set; }

        public string FavoriteBook3 { get; set; }

        public string Goal { get; set; }
    }
}
