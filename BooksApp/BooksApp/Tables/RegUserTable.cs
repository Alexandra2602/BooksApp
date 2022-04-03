using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Tables
{
    public class RegUserTable
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string imagePath { get; set; }
    }
}
