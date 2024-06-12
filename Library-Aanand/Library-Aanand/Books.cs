using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Library_Aanand
{
    public class Books
    {
        [PrimaryKey]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool BorrowingStatus { get; set; }
        public string Borrower { get; set; }


        public Books()
        {

        }

        // Overloaded constructor
        public Books(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
           BorrowingStatus = false;
            Borrower = "";
        }

    }


    

}
