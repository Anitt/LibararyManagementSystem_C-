using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Validation
{
    public class MemberValidation : IMemberValidation
    {
        //DateTime dateoutput;

        public Boolean ValidateMember(LibMember member) {

            MemberTable membertable = new MemberTable(new MySQLDatabase());
            IEnumerable<LibMember> Listofmembers = membertable.GetMembers();
            // for validating email members
            foreach (var singlemember in Listofmembers) {

                if (singlemember.Email == member.Email) {

                    return false;
                }
            }

            // for validating the first name

            if (member.Firstname.Any(char.IsDigit) || member.Firstname.Any(char.IsSymbol) || string.IsNullOrEmpty(member.Firstname))
            {

                return false;
            }

            // to check whether the Last name

            if (member.Lastname.Any(char.IsDigit) || member.Lastname.Any(char.IsSymbol) || string.IsNullOrEmpty(member.Lastname))
            {

                return false;
            }

            // to validate the email address
            var emailaddress = new System.Net.Mail.MailAddress(member.Email);
            if (!emailaddress.Equals(member.Email) && String.IsNullOrEmpty(member.Email))
            {

                return false;

            }

            // to validate Phone address

            if (member.Phone == null) {

                return false;
            }

            if (String.IsNullOrEmpty(member.Address)) {

                return false;
            }


            //parsing Date format and validating

            if (!DateTime.TryParse(member.Dob, out DateTime dateoutput))
            {
                return false;
              
            }


            return true;
        }

         
    }
}