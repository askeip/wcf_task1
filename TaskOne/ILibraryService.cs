using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TaskOne
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILibraryService" in both code and config file together.
    [ServiceContract]
    public interface ILibraryService
    {
        [OperationContract]
        void AddBook(Book value);

        [OperationContract]
        Book GetBook(int id);
        [OperationContract]
        List<Book> GetAllBooks(string author);

        [OperationContract]
        Book TakeBook(Book book);

        [OperationContract]
        void ReturnBook(Book book);
    }

    [DataContract]
    public enum BookType
    {
        [EnumMember] FictionBook,
        [EnumMember] Magazine,
        [EnumMember] Other,
        TakenBook
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Book
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public int PublishingYear { get; set; }
        [DataMember]
        public BookType BookType { get; set; }
        
        /*public Book(int id, string name, string author,
            int publishingYear, BookType bookType)
        {
            Id = id;
            Name = name;
            Author = author;
            PublishingYear = publishingYear;
            BookType = bookType;
        }*/

        public override int GetHashCode()
        {
            return Id * PublishingYear * Name.Length;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            Book otherBook = (Book) obj;
            return Id == otherBook.Id && Name == otherBook.Name && Author == otherBook.Author &&
                   PublishingYear == otherBook.PublishingYear && BookType == otherBook.BookType;
        }
    }
}
