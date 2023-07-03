using System;
using System.Collections.Generic;
using System.Text;
using ClubMembershipApplication.Models;
using System.Linq;


namespace ClubMembershipApplication.Data
{
    public class LoginUser : ILogin
    {
        public User Login(string emailAddress, string password)
        {
            User user = null;

            using (var dbContext = new ClubMembershipDbContext())
            {
               user = dbContext.Users.FirstOrDefault(user => user.EmailAddress.Trim().ToLower() == emailAddress.ToLower().Trim() && user.Password.Equals(password));
            }

            return user;
        }
    }
}
