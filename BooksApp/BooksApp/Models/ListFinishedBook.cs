using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Models
{
    public class ListFinishedBook
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Book))]
        public int BookID { get; set; }

        [ForeignKey(typeof(User))]
        public int UserID { get; set; }
   

        public int FinishedID { get; set; }

    }
}
