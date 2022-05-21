﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Models
{
    public class Finished
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        [OneToMany]
        public List<ListFinished> ListFinisheds { get; set; }
    }
}
