using System;
using System.Collections.Generic;
using System.Text;
using LibraryCollections.Classes.Abstract;

namespace LibraryCollections.Classes
{
    public class Book : Author
    {
        public string Title { get; set; }

        public Genre BookGenre { get; set; }

        public Book()
        {
            //Instantiate Empty Book
        }

        // Instantiate a book with unknown author
        public Book(string title, Genre bookGenre)
        {
            Title = title;
            BookGenre = bookGenre;
            Author unknownAuthor = new Author();
        }

        // Instantiate a book with an author
        public Book(string title, Genre bookGenre, string authFName, string authLName)
        {
            Title = title;
            BookGenre = bookGenre;
            Author Author = new Author(authFName, authLName);
        }
    }

    public enum Genre
    {
        Fantasy,
        Fiction,
        NonFiction,
        SciFi,
        Romance,
        Encyclopedia
    }
}
