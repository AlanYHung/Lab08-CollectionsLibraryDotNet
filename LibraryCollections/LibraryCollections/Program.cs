using System;
using System.Collections.Generic;
using LibraryCollections.Classes;

namespace LibraryCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Library<Book> bookCollection = populateLibrary();
                List<Book> bookBag = new List<Book>();
                userMenu(bookCollection, bookBag);
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong...{0}", e);
                PauseScreen();
            }
            finally
            {
                Console.Clear();
                Console.WriteLine("\nHave a Nice Day.\n");
            }
        }

        /// <summary>
        /// Creates an new Library instance and populates it with 5 default book objects.
        /// </summary>
        /// <returns>new Library instance</returns>
        public static Library<Book> populateLibrary()
        {
            Book book1 = new Book("All Quiet on the Western Front", Genre.Fiction, "Erich", "Remarque");
            Book book2 = new Book("The Sirens of Titan", Genre.SciFi, "Kurt", "Vonnegut");
            Book book3 = new Book("The Dragon Reborn", Genre.Fantasy, "Robert", "Jordan");
            Book book4 = new Book("Magical Mushrooms, Mischevious Molds", Genre.NonFiction, "George", "Hudler");
            Book book5 = new Book("Northwest Trees", Genre.Encyclopedia, "Ramona", "Hammerly");
            Library<Book> newLibrary = new Library<Book>();
            newLibrary.AddBook(book1);
            newLibrary.AddBook(book2);
            newLibrary.AddBook(book3);
            newLibrary.AddBook(book4);
            newLibrary.AddBook(book5);
            return newLibrary;
        }

        /// <summary>
        /// Method that controls user interface and calls subsequent methods
        /// </summary>
        /// <param name="bookCollection">Type Library and stores Book Objects</param>
        /// <param name="bookList">Type List and stores Book Objects</param>
        public static void userMenu(Library<Book> bookCollection, List<Book> bookBag)
        {
            string userInput;
            int userInputInt;

            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Welcome.  Please let us know what you would like to do today.\n");
                    Console.WriteLine("1. View All Books");
                    Console.WriteLine("2. Add a Book");
                    Console.WriteLine("3. Borrow a book");
                    Console.WriteLine("4. Return a book");
                    Console.WriteLine("5. View Book Bag");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nPlease choose a number (1-6): ");
                    userInput = Console.ReadLine();
                    userInputInt = Convert.ToInt32(userInput);

                    if(userInputInt < 1 || userInputInt > 6)
                    {
                        Console.Clear();
                        Console.WriteLine("You did not enter a number between 1 and 6.  Please choose again.");
                        PauseScreen();
                    }
                    else
                    {
                        Console.Clear();

                        switch (userInputInt)
                        {
                            case 1:
                                Console.WriteLine(ViewAllBooks(bookCollection));
                                PauseScreen();
                                break;
                            case 2:
                                userAddBook();
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                        }
                    }
                } while (userInputInt != 6);
            }
            catch(FormatException fe)
            {
                throw fe;
            }
        }

        /// <summary>
        /// Method to pause the screen output
        /// </summary>
        public static void PauseScreen()
        {
            Console.WriteLine("\n\nPlease press enter to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Method to view all books in the library
        /// </summary>
        /// <param name="bookCollection">This is the Library being viewed</param>
        /// <returns>String Output of all Books in the library</returns>
        public static string ViewAllBooks(Library<Book> bookCollection)
        {
            string output = $"You currently have {bookCollection.BookCount()} books in your library.\n\n";
            int count = 1;

            foreach (var libBook in bookCollection)
            {
                output += $"{count++}. {libBook.Title}\n";

            }

            return output;
        }

        public static Book userAddBook()
        {
            string userTitle;
            string userGenre = "";
            string userAuthFName = "";
            string userAuthLName = "";
            Book userBook = new Book();
            int numOfGenres;

            try
            {
                Console.WriteLine("What is the title of your Book?");
                userTitle = Console.ReadLine();

                //do
                //{
                    Console.WriteLine("What genre does your book belong to?\n\n");
                    numOfGenres = GenreOutput();
                //}while()

                return userBook;
            }
            catch(FormatException fe)
            {
                throw fe;
            }
        }

        public static int GenreOutput()    
        {
            int count = 1;
            var genreValues = Enum.GetValues(typeof(Genre));

            foreach (var genre in genreValues)
            {
                Console.WriteLine("{0}. {1}", count, genre);
                count++;
            }

            return count;
        }

        public static Book AddABook()
        {
            return new Book();
        }
    }
}
