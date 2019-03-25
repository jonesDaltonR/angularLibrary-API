using APILibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APILibrary.Classes;

namespace APILibrary.Controllers
{
    public class BookController : ApiController
    {
        // GET: api/Book
        public IEnumerable<Book> Get()
        {
            DBManager db = new DBManager();
            
            return db.GetBooks();
        }

        // GET: api/Book/5
        public IEnumerable<Book> Get(string query)
        {
            DBManager db = new DBManager();

            return db.SearchBooks(query);
        }
    }
}
