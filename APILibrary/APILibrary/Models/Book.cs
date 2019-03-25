using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILibrary.Models
{
    public class Book
    {
        public int id { get; set; }
        public string isbn { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public string author { get; set; }

        public Book(int id, string title, string description, string isbn, string genre,string author)
        {
            this.id = id;
            this.isbn = isbn;
            this.description = description;
            this.title = title;
            this.genre = genre;
            this.author = author;
        }
    }
}