using Library_Logic;
using Library_Logic.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebILS.Controllers
{
    public class LibraryController : Controller
    {
        public BookManager manager = new BookManager();

        //to get the info about available books
        public IActionResult Index()
        {
            List<Books> books = manager.GetAvailableBooks();
            return View(books);
        }

        // List of User books
        public IActionResult UserBooks()
        {
            List<UserBooks> books = manager.GetUserBooks();

            return View(books);
        }

        //to borrow a book
        public IActionResult Borrow(string title)
        {
            manager.TakeBook(title);
            //sends the user back to the list of his books (UserBooks)
            return RedirectToAction(nameof(UserBooks));
        }
        public IActionResult Return(string title)
        {
            manager.ReturnBook(title);
            //sends the user back to the list of his books (UserBooks)
            return RedirectToAction(nameof(UserBooks));
        }
    }
}

  
