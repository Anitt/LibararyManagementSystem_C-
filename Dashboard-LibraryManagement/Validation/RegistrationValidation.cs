using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Validation
{
    public class RegistrationValidation
    {
        public Boolean ValidateRegistration(UserAccount user)
        {

            try
            {
                UserTable usertable = new UserTable(new MySQLDatabase());
                IEnumerable<UserAccount> ListofUsers = usertable.GetUsers();
                foreach (var singleuser in ListofUsers)
                {

                    // to check whether the email id is already existing
                    if (singleuser.Email == user.Email)
                    {

                        return false;

                    }
                }


                // to check whether the Firstname contains only alphabets

                if (user.Firstname.Any(char.IsDigit) || user.Firstname.Any(char.IsSymbol) || string.IsNullOrEmpty(user.Firstname))
                {

                    return false;
                }
                
                // to check whether the Last name

                if (user.Lastname.Any(char.IsDigit) || string.IsNullOrEmpty(user.Lastname))
                {

                    return false;
                }

                // to validate the email address
                if (String.IsNullOrEmpty(user.Email))
                {
                    return false;
                }
                else
                {
                    var emailaddress = new System.Net.Mail.MailAddress(user.Email);
                    if (!emailaddress.Equals(user.Email))
                    {

                        return false;

                    }

                }

                // password validation logic 

                if (String.IsNullOrEmpty(user.Password) || (!(user.Password == user.ConfirmPassword))) {

                    return false;

                }

                // confirm validation logic 

                if (String.IsNullOrEmpty(user.ConfirmPassword)) {

                    return false;
                }

                

            }
            catch (Exception)
            {

                throw;
            }

            return true;


        }
    }
}