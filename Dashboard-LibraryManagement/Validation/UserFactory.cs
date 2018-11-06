using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Validation
{
	public class UserFactory : AbstractFactory
	{
		public override IBookValidation getbookvalidation(string bookvalidation)
		{
			return null;
		}

		public override IMemberValidation getmembervalidation(string membervalidation)
		{
			return null;
		}

		public override IUserValidation getuservalidation(string uservalidation)
		{
			if (uservalidation == null) {

				return null;
			}

			if (uservalidation.Equals("UserValidation", StringComparison.InvariantCultureIgnoreCase)) {


				return new UserValidation();

			}

			return null;
		}
	}
}