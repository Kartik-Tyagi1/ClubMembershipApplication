using System;
using System.Collections.Generic;
using System.Text;

namespace ClubMembershipApplication.Data
{
    public interface IRegister
    {
        
        bool Register(string[] fields); // fields contains all valid fields from form

        bool EmailExists(string emailAddress); // for email exists delegate
    }
}
