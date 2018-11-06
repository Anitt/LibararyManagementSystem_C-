using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Validation
{
	public abstract class AbstractFactory
	{
		public abstract IBookValidation getbookvalidation(String bookvalidation);
		public abstract IMemberValidation getmembervalidation(String membervalidation);
        public abstract IUserValidation getuservalidation(String uservalidation);
	}
}