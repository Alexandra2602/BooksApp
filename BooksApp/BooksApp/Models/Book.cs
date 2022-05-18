﻿using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages { get; set; }
        public int YearPublished { get; set; }
        public string ImagePath { get; set; }
        public string Year_Month { get; set; }

        public float Average_Rating { get; set; }
        public float Number { get; set; }
        public int Top { get; set; }
    }
}

