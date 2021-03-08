using Library_Logic.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Library_Logic
{
    /// <summary>
    /// All the logic for taking/returning books
    /// </summary>
    public class BookManager
    {       
        public BookManager()
        {
        }
        /// <summary>
        /// Returns list of all available books
        /// </summary>
        /// <returns></returns>
        public List<Books> GetAvailableBooks()
        {
            //    //return LibraryBooks.AvBooks
            //    //                 .Where(book => book.Copies > 0)
            //    //                 .OrderBy(book => book.Title)
            //    //                 .ToList();
            //    List<Book> result = new List<Book>();
            //    string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Stephen\Documents\Natalija\Accenture .Net\Bootcamp1\LibraryDB.mdf;Integrated Security=True;Connect Timeout=30";


            using (LibraryDatabase db = new LibraryDatabase())
            {
                return db.Books.Where(b => b.Copies > 0)
                                      .OrderBy(b => b.Title).ToList();                
            }
        }

        public List<UserBooks> GetUserBooks()
        {
            using (LibraryDatabase db = new LibraryDatabase())
            {
                return db.UserBooks.OrderBy(b => b.Title).ToList();
            }
            //return UserBooks.Books.OrderBy(book => book.Title).ToList();
        }

       public Books TakeBook(string title)
       {
           //Book book = LibraryBooks.AvBooks.Find(book =>
           //book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
           using(LibraryDatabase db = new LibraryDatabase())
           {
                var book = db.Books.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());

                if (book != null && book.Copies > 0)
                {
                    book.Copies--;
                    db.UserBooks.Add(new UserBooks()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Year = book.Year
                    });
                    
                    db.SaveChanges();
                    return book;
                }               
           }
            return null;            
       }
        public Books ReturnBook(string title)
        {
            using(LibraryDatabase db = new LibraryDatabase())
            {
                var book = db.UserBooks.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());
                if(book != null)
                {
                    db.UserBooks.Remove(book);
                    var returnedBook = db.Books.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());
                    returnedBook.Copies++;
                    db.SaveChanges();
                    return returnedBook;
                }
            }
            return null;           
        }
        public void BackgroundColor()
        {
            Console.BackgroundColor = ConsoleColor.Green;
        }
        public void ForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
