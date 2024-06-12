using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Library_Aanand
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        //Login Button 
        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            string username = usernameinput.Text;
            string password = passwordinput.Text;

            //validations of username and password
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                labelerrormsg.IsVisible = true;
                labelerrormsg.Text = "ERROR: Username or password cannot be empty";
            }
            else
            {
                if ((username == "peter" && password == "1234") || (username == "mary" && password == "0000"))
                {
                    
                    await Navigation.PushAsync(new BookListScreen(username));
                }
                else
                {
                    labelerrormsg.Text = "ERROR: Wrong username or password.";
                    labelerrormsg.IsVisible = true;
                }


            }


        }

        //Back to login page
        protected override void OnAppearing()
        {
            base.OnAppearing();

            usernameinput.Text = "";
            passwordinput.Text = "";

            labelerrormsg.IsVisible = false;
            labelerrormsg.Text = "";
        }
    }
}
