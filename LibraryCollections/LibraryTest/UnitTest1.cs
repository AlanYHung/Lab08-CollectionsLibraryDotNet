using System;
using Xunit;
using LibraryCollections;
using LibraryCollections.Classes;

namespace LibraryTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddBook()
        {
            Library<Book> bookCollection = new Library<Book>();
            Book newBook = new Book("I am a book", Genre.Fiction, "FirstName", "LastName");
            bookCollection.AddBook(newBook);

            Assert.NotNull(bookCollection);
            
        }

        [Fact]
        public void RemoveBookFromLibrary()
        {
            Library<Book> bookCollection = new Library<Book>();
            Book newBook = new Book("I am a book", Genre.Fiction, "FirstName", "LastName");
            bookCollection.AddBook(newBook);
            bookCollection.RemoveBook(newBook);

            Assert.Equal(0, bookCollection.BookCount());
        }

        [Fact]
        public void CannotRemoveNonexistentBook()
        {
            Library<Book> bookCollection = new Library<Book>();
            Book newBook = new Book("I am a book", Genre.Fiction, "FirstName", "LastName");
            bookCollection.AddBook(newBook);

            Assert.Throws<Exception>(() => Program.Borrow(3, bookCollection));
        }

        [Fact]
        public void TestGetSetBook()
        {
            Book testBook = new Book();
            testBook.Title = "I am a book!";

            Assert.Equal("I am a book!", testBook.Title);
        }

        [Fact]
        public void TestGetSetAuthor()
        {
            Book testAuthor = new Book("I am a book", Genre.Fiction, "Carlos", "LastName");

            Assert.Equal("Carlos", testAuthor.FirstName);
        }

        [Fact]
        public void GetLibraryCount()
        {
            Library<Book> bookCollection = new Library<Book>();
            Book newBook = new Book("I am a book", Genre.Fiction, "FirstName", "LastName");
            bookCollection.AddBook(newBook);

            Assert.Equal(1, bookCollection.BookCount());
        }

        [Fact]
        public void TestUnknownAuthor() {
            Book newBook = new Book("I am a book", Genre.Fiction);

            Assert.Equal("Unknown", newBook.FirstName);
        }
    }
}
