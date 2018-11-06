using Dashboard_LibraryManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.PasswordValidate
{
	public class PasswordExistCheck : IPassword
	{
		private IPassword nextInProperty;

		public IPassword CheckNextProp(IPassword nextProp)
		{
			this.nextInProperty = nextProp;
			return nextProp;
		}

		public bool checkPassword(PropertyCheck password)
		{
			if (!string.IsNullOrEmpty(password.getPassword()))
			{

				return nextInProperty != null ? nextInProperty.checkPassword(password) : true;
			}
			else
				return false;
		}

	}
}