using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Validation
{
    public class UserValidation : IUserValidation
    {
        public Boolean ValidateUser(string Email, string password, out UserAccount userAccount)
        {

            try
            {
                userAccount = null;
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))
                    return false;
                UserTable userTable = new UserTable(new MySQLDatabase());
                userAccount = userTable.GetUsersByEmailId(Email);

                if (userAccount == null)
                    return false;

                if (Email == userAccount.Email && password == userAccount.Password)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;  
        }

    }
}