using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Validation
{
	public class BookFactory : AbstractFactory
	{
		public override IBookValidation getbookvalidation(string bookvalidation)
		{
			if (bookvalidation == null) {

				return null;

			}

			if (bookvalidation.Equals("BookValidation", StringComparison.InvariantCultureIgnoreCase)) {

				return new BookValidation();
			}

			return null;
		}

		public override IMemberValidation getmembervalidation(string membervalidation)
		{
			return null;
		}

		public override IUserValidation getuservalidation(string uservalidation)
		{
			return null;
		}
	}
}