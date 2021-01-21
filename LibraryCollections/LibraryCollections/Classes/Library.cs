using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LibraryCollections.Classes
{
    class Library<T> : IEnumerable
    {
        T[] books = new T[5];
        int length;

        public int BookCount()
        {
            return length;
        }

        public void AddBook(T book)
        {
            if (length == books.Length)
            {
                Array.Resize(ref books, books.Length * 2);
            }

            books[length++] = book;
        }

        public void RemoveBook(T book)
        {
            int bookToRemove = Array.IndexOf(books, book);
            int index = 0;

            foreach (var currBook in books)
            {
                if(bookToRemove <= index)
                {
                    books[index] = books[index + 1];
                }
            }

            length--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < length; i++)
            {
                yield return books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
