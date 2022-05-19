using SQLite;
using System;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Models
{
    public class RatingModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Description { get; set; }
        [OneToMany]
     public string UserName { get; set; }
        public List<ListRating> ListRatings { get; set; }
    }
}
