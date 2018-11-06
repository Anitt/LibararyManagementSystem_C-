using Dashboard_LibraryManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.PasswordValidate
{
    public class DigitCheck:IPassword
    {
        private IPassword nextInProperty;

        public IPassword CheckNextProp(IPassword nextProp)
        {
            this.nextInProperty = nextProp;
			return nextProp;
        }

        public bool checkPassword(PropertyCheck password)
        {
            if (password.getPassword().Any(char.IsDigit))
            {

                return nextInProperty != null ? nextInProperty.checkPassword(password) : true;
            }
            else
                return false;
        }
    }
}