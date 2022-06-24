﻿using SQLite;
using System;
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
        public float Total { get; set; }
        public float Number { get; set; }
    }
}

