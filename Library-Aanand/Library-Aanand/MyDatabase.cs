using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO; 


namespace Library_Aanand
{
    public class MyDatabase
    {

        // 1. Define a property that represents the connection to the database
        readonly SQLiteAsyncConnection dbConnection;

        public MyDatabase()
        {

            // Configure the connection

            // - specifying the name of the database file
            string databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "BookDatabase.db");
            Console.WriteLine($"++++++ Database path: {databasePath}");

            // - specify "where" on the device the file will be saved
            dbConnection = new SQLiteAsyncConnection(databasePath);

            // Create the table (based on the TodoItem)
            dbConnection.CreateTableAsync<Books>().Wait();

            // Done!
            Console.WriteLine($"++++++ Database table created!");

            //Insert Books in db
            InitializeDatabaseAsync().Wait();

        }

        private async Task InitializeDatabaseAsync()
        {
            //Delete Previous Books of db
            await dbConnection.DeleteAllAsync<Books>();

            List<Books> books = new List<Books>
            {
            new Books("3245679981", "Homodeus", "Yuval Noah Harari"),
            new Books("3355886790", "How to win friends and influence people", "Dale Carnegie"),
            new Books("2245673290", "The Alchemist", "Paulo Coelho"),
             new Books("97814767531", "Ugly Love", "Colleen Hoover")
            };

            await dbConnection.InsertAllAsync(books);
        }

        //Get All book list from db
        public async Task<List<Books>> GetAllBooks()
        {
            List<Books> books = await dbConnection.Table<Books>().ToListAsync();
            return books;
        }

        //Get that ISBN book details from db
        public async Task<Books> GetBookByISBN(string ISBN)
        {
            Books book = await dbConnection.GetAsync<Books>(ISBN);
            return book;
        }

        //Updating book in db
        public async Task<int> UpdateBook(Books book)
        {
            return await dbConnection.UpdateAsync(book);
        }
    }
}
