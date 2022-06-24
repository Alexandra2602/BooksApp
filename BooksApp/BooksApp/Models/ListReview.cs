using SQLite;
using SQLiteNetExtensions.Attributes;


namespace BooksApp.Models
{
    public class ListReview
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Book))]
        public int BookID { get; set; }
        [ForeignKey(typeof(User))]
        public int UserID { get; set; }
        public int ReviewID { get; set; }
    }
}
