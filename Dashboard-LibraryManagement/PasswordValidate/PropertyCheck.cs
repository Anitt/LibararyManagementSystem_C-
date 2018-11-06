using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.PasswordValidate
{
    public class PropertyCheck
    {
        private string password;

        public PropertyCheck(string nextpassword)
        {
            password = nextpassword;
        }

        public string getPassword()
        {
           return password;
        }

    }
}