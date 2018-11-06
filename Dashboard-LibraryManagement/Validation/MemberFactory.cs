using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Validation
{
	public class MemberFactory : AbstractFactory
	{
		public override IBookValidation getbookvalidation(string bookvalidation)
		{
			return null;
		}

		public override IMemberValidation getmembervalidation(string membervalidation)
		{
			if (membervalidation == null) {
				return null;
			}

			if (membervalidation.Equals("MemberValidation", StringComparison.InvariantCultureIgnoreCase)) {

				return new MemberValidation();
			}

			return null;
		}

		public override IUserValidation getuservalidation(string uservalidation)
		{
			return null;
		}
	}
}