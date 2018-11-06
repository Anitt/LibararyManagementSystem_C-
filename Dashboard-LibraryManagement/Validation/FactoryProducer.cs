using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Validation
{
	public class FactoryProducer
	{
		public static AbstractFactory GetFactory(String factorychoice)
		{

			if (factorychoice.Equals("IBookValidation", StringComparison.InvariantCultureIgnoreCase))
			{

				return new BookFactory();
			}
			else if (factorychoice.Equals("IMemberValidation", StringComparison.InvariantCultureIgnoreCase))
			{

				return new MemberFactory();
			}

			else if (factorychoice.Equals("IUserValidation", StringComparison.InvariantCultureIgnoreCase))
			{

				return new UserFactory();
			}

			return null;
		}
	}
}