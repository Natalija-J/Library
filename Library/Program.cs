using System;
using Library_Logic;
namespace Library_Console
{
    public class Program
    {
        static BookManager manager = new BookManager();
        static void Main(string[] args)
        {
            manager.BackgroundColor();
            manager.ForegroundColor();
            Console.WriteLine("Welcome to the library!");
            Console.WriteLine("Books available:");
            Console.ResetColor();
            Console.WriteLine();

            var books = manager.GetAvailableBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("There are no available books at the moment.");
            }
            else
            {
                books.ForEach(book =>
                {
                    Console.WriteLine("{0} ({1}) {2} (Available copies: {3})", book.Title, book.Author, book.Year, book.Copies);
                });
            }
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Please enter a title of a book you wish to borrow " +
                    "(or 'stop' to quit): ");
                string input = System.Console.ReadLine();

                if (input == "stop" || input == "STOP" || input == "Stop")
                {
                    break;
                }

                var bookBorrowed = manager.TakeBook(input);
                if (bookBorrowed == null)
                {
                    System.Console.WriteLine("The book is not available!");
                }
                else
                {
                    Console.WriteLine("The book '{0}' was successfully checked out!", bookBorrowed.Title);
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            manager.BackgroundColor();
            manager.ForegroundColor();
            Console.WriteLine("Your books: ");
            Console.ResetColor();
            var myList = manager.GetUserBooks();
            if (myList.Count == 0)
            {
                Console.WriteLine("You have not checked out any books.");
            }
            else
            {
                foreach (var book in myList)
                {
                    Console.WriteLine("'{0}' by {1} ({2})",
                        book.Title, book.Author, book.Year);
                }
                Console.WriteLine();
                manager.BackgroundColor();
                manager.ForegroundColor();
                Console.WriteLine("Returning books.");
                Console.ResetColor();

                while (true)
                {
                    Console.WriteLine("Please enter a book title that you wish to return" +
                        "(or 'stop' to exit): ");
                    string input2 = System.Console.ReadLine();
                    if (input2 == "stop" || input2 == "STOP" || input2 == "Stop")
                    {
                        break;
                    }

                    var returned = manager.ReturnBook(input2);
                    if (returned == null)
                    {
                        System.Console.WriteLine("Sorry, this book has not been checked out by you!");
                    }
                    else
                    {
                        System.Console.WriteLine("'{0}' by {1} has been returned to the library (available copies: {3})",
                        returned.Title, returned.Author, returned.Copies);
                    }
                }
                System.Console.WriteLine();
                manager.BackgroundColor();
                manager.ForegroundColor();
                System.Console.WriteLine("Books that have not been returned yet: ");
                System.Console.ResetColor();

                foreach (var book in manager.GetUserBooks())
                {
                    System.Console.WriteLine("'{0}' by {1} ({2})",
                        book.Title, book.Author, book.Year);
                }

            }
            System.Console.WriteLine();
            manager.BackgroundColor();
            manager.ForegroundColor();
            System.Console.Write("Thank you for using our library!");
            System.Console.ResetColor();
        }
    }
}
