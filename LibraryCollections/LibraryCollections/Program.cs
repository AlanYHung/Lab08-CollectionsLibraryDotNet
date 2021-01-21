using System;
using System.Collections.Generic;
using LibraryCollections.Classes;

namespace LibraryCollections
{
    public class Program
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
                                bookCollection.AddBook(userAddBook());
                                break;
                            case 3:
                                bookBag.Add(userBorrow(bookCollection));
                                break;
                            case 4:
                                ReturnBook(bookBag, bookCollection);
                                break;
                            case 5:
                                Console.WriteLine(ViewBookBag(bookBag));
                                PauseScreen();
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
                output += $"{count++}. {libBook.Title} - {libBook.FirstName} {libBook.LastName}\n";

            }

            return output;
        }

        /// <summary>
        /// User Interfact to get Title, Genre, and Author Name
        /// </summary>
        /// <returns>returns the newbook returned by AddABook method</returns>
        public static Book userAddBook()
        {
            string userTitle;
            string userGenre;
            int userGenreInt;
            string userAuthorKnown;
            string userAuthFName = "";
            string userAuthLName = "";
            int numOfGenres;

            try
            {
                Console.WriteLine("What is the title of your Book?");
                userTitle = Console.ReadLine();

                do
                {
                    Console.Clear();
                    Console.WriteLine("What genre does your book belong to?\n\n");
                    numOfGenres = GenreOutput();
                    Console.Write("\nPlease choose a number (1-{0}): ", numOfGenres);
                    userGenre = Console.ReadLine();
                    userGenreInt = Convert.ToInt32(userGenre);

                    if(userGenreInt < 1 || userGenreInt > numOfGenres)
                    {
                        Console.Clear();
                        Console.WriteLine("\nInvalid Choice.  Please choose a number between 1 and {0}.", numOfGenres);
                        PauseScreen();
                    }
                } while (userGenreInt < 1 || userGenreInt > numOfGenres);

                do
                {
                    Console.Clear();
                    Console.Write("Do you know the Author for this book? (y/n): ");
                    userAuthorKnown = Console.ReadLine().ToLower();

                    if (userAuthorKnown != "y" && userAuthorKnown != "n")
                    {
                        Console.WriteLine("Please enter 'y' or 'n'.");
                        PauseScreen();
                    }
                } while (userAuthorKnown != "y" && userAuthorKnown != "n");

                if(userAuthorKnown == "y")
                {
                    Console.WriteLine("What is the Author's First Name?");
                    userAuthFName = Console.ReadLine();
                    Console.WriteLine("What is the Author's Last Name?");
                    userAuthLName = Console.ReadLine();
                }

                // https://stackoverflow.com/questions/23563960/how-to-get-enum-value-by-string-or-int
                return AddABook(userTitle, (Genre)userGenreInt, userAuthFName, userAuthLName);
            }
            catch(FormatException fe)
            {
                throw fe;
            }
        }

        /// <summary>
        /// Outputs the values of the Enum Variable Genre
        /// </summary>
        /// <returns>Length of Genre</returns>
        public static int GenreOutput()    
        {
            int count = 1;
            var genreValues = Enum.GetValues(typeof(Genre));

            foreach (var genre in genreValues)
            {
                Console.WriteLine("{0}. {1}", count, genre);
                count++;
            }

            return count - 1;
        }

        /// <summary>
        /// Returns a new Book using the parameters sent in to instantiate the Object
        /// </summary>
        /// <param name="newTitle">Book Title</param>
        /// <param name="newGenre">Book Genre</param>
        /// <param name="authFName">Author First Name</param>
        /// <param name="authLName">Author Last Name</param>
        /// <returns>new Book Instance</returns>
        public static Book AddABook(string newTitle, Genre newGenre, string authFName, string authLName)
        {
            if(authFName == "")
            {
                return new Book(newTitle, newGenre);
            }
            else
            {
                return new Book(newTitle, newGenre, authFName, authLName);
            }
        }

        /// Displays books availible to borrow to the user then allows them to select one and calls the borrow method for that book
        /// param name="bookCollection" brings in the library
        /// returns: the borrowed book
        public static Book userBorrow(Library<Book> bookCollection)
        {
            string userInput;
            int userInputInt;

            do
            {
                Console.Clear();
                Console.WriteLine("What book would you like to borrow?\n");
                Console.WriteLine(ViewAllBooks(bookCollection));
                Console.Write("Please make a selection between (1-{0}): ", bookCollection.BookCount());
                userInput = Console.ReadLine();
                userInputInt = Convert.ToInt32(userInput);

                if(userInputInt < 1 || userInputInt > bookCollection.BookCount())
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a value between 1 and {0}", bookCollection.BookCount());
                    PauseScreen();
                }
            } while (userInputInt < 1 || userInputInt > bookCollection.BookCount());

            return Borrow(userInputInt, bookCollection);
        }

        /// loops over all books in the book library and removes the chosen book from the library
        /// param name="bookTitle" the user inputted title
        /// param name="bookCollection" the established collection of books
        /// returns: the book to be moved to the book list
        public static Book Borrow(int userChoice, Library<Book> bookCollection)
        {
            int count = 1;

            foreach (Book books in bookCollection)
            {
                if (count == userChoice)
                {
                    bookCollection.RemoveBook(books);
                    return books;
                }

                count++;
            }

            throw new Exception("Book not Found!!");
        }

        /// <summary>
        /// Method to Display all items in the Book Bag
        /// </summary>
        /// <param name="bookBag">List passed Forward</param>
        /// <returns>String Output</returns>
        public static string ViewBookBag(List<Book> bookBag)
        {
            string output = $"You currently have {bookBag.Count} books in your Book Bag.\n\n";
            int count = 1;

            foreach (var bagBook in bookBag)
            {
                output += $"{count++}. {bagBook.Title} - {bagBook.FirstName} {bagBook.LastName}\n";
            }

            return output;
        }

        public static void ReturnBook(List<Book> bookBag, Library<Book> bookCollection)
        {
            // Instantiates a Dictionary Object
            Dictionary<int, Book> books = new Dictionary<int, Book>();

            // Prompt User to choose book to return
            Console.WriteLine("Choose a book to return to the library: ");

            // Counter to count the books in the book bag start at first item
            int counter = 1;

            // Iterate through each item in the book bag
            foreach (var item in bookBag)
            {
                // Add Key Value Pair to Dictionary
                books.Add(counter, item);

                // Lists out the books in book bag in numerical order
                Console.WriteLine($"{counter++}. {item.Title} - {item.FirstName} {item.LastName}");
            }

            // Reads in the user response on which book to return
            string response = Console.ReadLine();

            // Parse the response into an Int otherwise throw an error
            int.TryParse(response, out int selection);

            // Get the book that corresponds the user input or throw an error
            books.TryGetValue(selection, out Book returnedBook);

            // Removes the book from the Book Bag
            bookBag.Remove(returnedBook);

            // Adds the Book back to the library Collection
            bookCollection.AddBook(returnedBook);

        }
    }
}
