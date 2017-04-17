using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TaskOne
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LibraryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LibraryService.svc or LibraryService.svc.cs at the Solution Explorer and start debugging.
    public class LibraryService : ILibraryService
    {
        private static readonly List<Book> AvailableBooks = new List<Book>();
        private static readonly Dictionary<int, Book> TakenBooks = new Dictionary<int, Book>();
        private static readonly Book TakenBook = new Book {BookType = BookType.TakenBook};

        public LibraryService() //: this(new List<Book>(), new List<bool>())
        {
        }

/*        public LibraryService(List<Book> availableBooks, List<bool> takenBooks)
        {
            LibraryService.availableBooks = availableBooks;
            LibraryService.takenBooks = takenBooks;
        }*/

        public void AddBook(Book value)
        {
            value.Id = AvailableBooks.Count;
            AvailableBooks.Add(value);
        }

        public Book GetBook(int id)
        {
            if (AvailableBooks.Count >= id + 1 && !AvailableBooks[id].Equals(TakenBook))
            {
                return AvailableBooks[id];
            }
            return null;
        }

        public List<Book> GetAllBooks(string author)
        {
            return AvailableBooks.Where(z => z.Author == author)
                .ToList();
        }

        public Book TakeBook(Book book)
        {
            var bookToTake = AvailableBooks.FirstOrDefault(z => z.Equals(book)); //if no book check
            if (bookToTake != null)
            {
                AvailableBooks[bookToTake.Id] = TakenBook;
                TakenBooks.Add(bookToTake.Id, bookToTake);
            }
            return bookToTake;
        }

        public void ReturnBook(Book book)
        {
            if (!TakenBooks.Any(z => z.Value.Equals(book))) return;
            TakenBooks.Remove(book.Id);
            AvailableBooks[book.Id] = book;
        }
    }
}
