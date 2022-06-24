using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;


namespace BooksApp.Models
{
    public class RatingModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Description { get; set; }
        public string UserName { get; set; }

        [OneToMany]
    
        public List<ListRating> ListRatings { get; set; }
    }
}
