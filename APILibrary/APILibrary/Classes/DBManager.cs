using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using APILibrary.Models;

namespace APILibrary.Classes
{
    public class DBManager
    {
        SQLiteConnection connection;

        public DBManager()
        {
            
        }

        public Book[] GetBooks()
        {
            List<Book> books = new List<Book>();
            string sql = "SELECT book_id,title,description,isbn,genre_description as genre,author_name as author FROM BOOK INNER JOIN GENRE ON GENRE.genre_id = BOOK.genre_id INNER JOIN AUTHOR ON AUTHOR.author_id = Book.author_id";

            using (connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Library"].ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    books.Add(
                            ParseBook(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5)
                            )
                        );
                }
                connection.Close();
            }
            
            return books.ToArray();
        }
        public Book[] SearchBooks(string query)
        {
            List<Book> books = new List<Book>();
            string sql = "SELECT book_id,title,description,isbn,genre_description as genre,author_name as author "+
                         "FROM BOOK "+
                         "INNER JOIN GENRE ON GENRE.genre_id = BOOK.genre_id "+
                         "INNER JOIN AUTHOR ON AUTHOR.author_id = Book.author_id "+
                         "WHERE title LIKE @title OR description LIKE @description OR genre_description LIKE @genre OR author_name LIKE @author";
            using (connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Library"].ConnectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sql,connection);

                command.Parameters.AddWithValue("@title", "%" + query + "%");
                command.Parameters.AddWithValue("@description", "%" + query + "%");
                command.Parameters.AddWithValue("@genre", "%" + query + "%");
                command.Parameters.AddWithValue("@author", "%" + query + "%");

                SQLiteDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    books.Add(
                            ParseBook(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5)
                            )
                        );
                }
                connection.Close();
            }
            return books.ToArray();
        }

        private Book ParseBook(int id, string isbn, string title, string description, string genre, string author)
        { 
            return new Book(id, isbn, title, description, genre, author);
        }
    }
}