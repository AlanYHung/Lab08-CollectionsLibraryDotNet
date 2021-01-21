using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCollections.Classes.Abstract
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author()
        {
            FirstName = "Unknown";
            LastName = "Author";
        }

        public Author (string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }
    }
}
