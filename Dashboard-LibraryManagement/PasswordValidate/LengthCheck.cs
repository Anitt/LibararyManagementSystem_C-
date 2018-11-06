using Dashboard_LibraryManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Dashboard_LibraryManagement.PasswordValidate
{
    public class LengthCheck : IPassword
    {
        private IPassword nextInProperty;
		public IPassword CheckNextProp(IPassword nextProp)
		{
			this.nextInProperty = nextProp;
			return nextProp;
		}

		public bool checkPassword(PropertyCheck password)
        {
            if (password.getPassword().Length >8)
            {
                return nextInProperty != null ? nextInProperty.checkPassword(password) : true;
            }
            else
                return false;

        }

    }
}