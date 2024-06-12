using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library_Aanand
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class BookListScreen : ContentPage
{

        static List<Books> allBooks;
        string loggedUsername; 

      
        public BookListScreen(string username)
        {
            //Get All books from db before screen loading
            Task.Run(async () => { allBooks = await App.MyDb.GetAllBooks();}).Wait();
            InitializeComponent();

            labelName.Text = "Welcome "+username +"!";

            bookList.ItemsSource = allBooks;
            loggedUsername = username;


        }

        private void lstBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Books bookSelected = (Books)e.SelectedItem;
            string msgLabel = "";

            if (bookSelected.BorrowingStatus)
            {
                if (bookSelected.Borrower.Equals(loggedUsername))
                {
                    msgLabel = "You have this book checked out!";
                }
                else
                {
                    msgLabel = "Sorry, " + bookSelected.Title + " is already checked out by " + bookSelected.Borrower;
                }
            }
            else
            {
                msgLabel = bookSelected.Title + " is available";
            }

            labelMsg.Text = msgLabel;
            labelMsg.IsVisible = true;

        }

        private async void MenuItem_Checkout(object sender, EventArgs e)
        {
            string bookSelISBN = (string)(((MenuItem)sender).CommandParameter);

            Books bookSelected = await App.MyDb.GetBookByISBN(bookSelISBN);

           
            string msgLabel;

            if (bookSelected.BorrowingStatus)
            {
                if (bookSelected.Borrower.Equals(loggedUsername))
                {
                    msgLabel = "You have this book checked out!";
                }
                else
                {
                    msgLabel = "This book is already checked out by " + bookSelected.Borrower;
                }
                await App.Current.MainPage.DisplayAlert("Error", msgLabel, "OK");


            }
            else
            {
                bookSelected.BorrowingStatus = true;
                bookSelected.Borrower = loggedUsername;

                await App.MyDb.UpdateBook(bookSelected);

                allBooks = await App.MyDb.GetAllBooks();
                bookList.ItemsSource = allBooks;

                await App.Current.MainPage.DisplayAlert("Success", "DONE!", "OK"); 


            }
           
      
        }

        private async void MenuItem_Returned_1(object sender, EventArgs e)
        {
            string bookSelISBN = (string)(((MenuItem)sender).CommandParameter);

            Books bookSelected = await App.MyDb.GetBookByISBN(bookSelISBN);

            
            string msgLabel;


            if (bookSelected.BorrowingStatus)
            {
                if (bookSelected.Borrower.Equals(loggedUsername))
                {
                    bookSelected.BorrowingStatus= false;
                    bookSelected.Borrower = "";

                    await App.MyDb.UpdateBook(bookSelected);

                    allBooks = await App.MyDb.GetAllBooks();
                    bookList.ItemsSource = allBooks;


                    await App.Current.MainPage.DisplayAlert("Success", "DONE!", "OK");
                }
                else
                {
                    msgLabel = "The book cannot be returned";
                    await App.Current.MainPage.DisplayAlert("Error", msgLabel, "OK");
                }

            }
            else
            {
                msgLabel = "This book cannot be returned";
                await App.Current.MainPage.DisplayAlert("Error", msgLabel, "OK");


            }

        }
    }
}