﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Models
{
    class Users
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}