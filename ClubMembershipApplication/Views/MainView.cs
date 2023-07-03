using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubMembershipApplication.Views
{
    public class MainView : IView
    {
        IView _registerView = null;
        IView _loginView = null;

        public MainView(IView registerView, IView loginView)
        {
            _registerView = registerView;
            _loginView = loginView;
        }

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            Console.WriteLine($"Press 'L' To Login{Environment.NewLine}Press 'R' to Register if you are not yet registered");
            
            ConsoleKey key = Console.ReadKey().Key;
            if(key == ConsoleKey.L)
            {
                RunUserLoginView();
            }
            else if(key == ConsoleKey.R)
            {
                RunUserRegistrationView();
                RunUserLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Good Bye");
                Console.ReadKey();
            }
        }

        private void RunUserRegistrationView()
        {
            _registerView.RunView();
        }

        private void RunUserLoginView()
        {
            _loginView.RunView();
        }
    }
}
