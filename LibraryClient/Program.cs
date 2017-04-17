using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryClient.ServiceReference1;

namespace LibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new LibraryServiceClient();
            var book = new Book
            {
                Name = "name",
                Author = "author",
                PublishingYear = 2017,
                BookType = BookType.FictionBook
            };
            var book1 = new Book
            {
                Name = "name2",
                Author = "author2",
                PublishingYear = 2017,
                BookType = BookType.Magazine
            };
            client.AddBook(book);
            client.AddBook(book1);
            PrintBook(client.GetBook(0));
            client.TakeBook(book);
            PrintBook(client.GetBook(1));
            client.ReturnBook(book);
            var books = client.GetAllBooks("author");
            foreach (var e in books)
            {
                PrintBook(e);
            }

        }

        static void PrintBook(Book book)
        {
            if (book == null)
                Console.WriteLine("It is null");
            else
                Console.WriteLine(book.Id + ", author: " + book.Author);
        }
    }
}
