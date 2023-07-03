using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubMembershipApplication.Views
{
    public class UserLoginView : IView
    {
        ILogin _loginUser = null;

        public IFieldValidator FieldValidator => null;

        public UserLoginView(ILogin login)
        {
            _loginUser = login;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();

            string emailAddress = "";
            string password = "";

            Console.WriteLine("Please Enter Your Email");
            emailAddress = Console.ReadLine();

            Console.WriteLine("Please Enter Your Password");
            password = Console.ReadLine();

            User user = _loginUser.Login(emailAddress, password);

            if(user != null)
            {
                WelcomeUserView welcomeUserView = new WelcomeUserView(user);
                welcomeUserView.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials you have entered do not match our records");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            }

        }
    }
}
