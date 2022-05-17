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
        public string Description { get; set; }
        [OneToMany]
        public List<ListRating> ListRatings { get; set; }
    }
}
