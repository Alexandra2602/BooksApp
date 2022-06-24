﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace BooksApp.Models
{
    public class FinishedBook
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        [OneToMany]
        public List<ListFinishedBook> ListFinishedBooks { get; set; }

    }
}
