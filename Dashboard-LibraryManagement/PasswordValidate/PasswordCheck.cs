using Dashboard_LibraryManagement.Interfaces;
using System.Configuration;
using System.Linq.Expressions;
using System.Linq;

namespace Dashboard_LibraryManagement.PasswordValidate
{
	public class PasswordCheck
	{
		public IPassword Setup()
		{
			IPassword rootNode = new PasswordExistCheck();
			IPassword baseNode = rootNode;

			if (GetBusinessConfiguration("UserPasswordLength") != null)
			{
				baseNode = baseNode.CheckNextProp(new LengthCheck());
			}
			if (GetBusinessConfiguration("UserPasswordCheckUpperCase") != null)
			{
				baseNode = baseNode.CheckNextProp(new UppercaseCheck());
			}

			if (GetBusinessConfiguration("UserPasswordCheckLowerCase") != null)
			{
				baseNode = baseNode.CheckNextProp(new LowercaseCheck());
			}
			 if (GetBusinessConfiguration("UserPasswordCheckDigits") != null)
			{
				baseNode = baseNode.CheckNextProp(new DigitCheck());
			}

			return rootNode;
		}
		public bool CheckPassword(string password)
		{
			IPassword finalPasswordChecker = Setup();
			PropertyCheck property = new PropertyCheck(password);
			return finalPasswordChecker.checkPassword(property);
		}


		public string GetBusinessConfiguration(string keyName)
		{
			var keyExist = ConfigurationManager.AppSettings.AllKeys.Contains(keyName);
			if (keyExist)
				return ConfigurationManager.AppSettings[keyName];
			else
				return null;
		}
	}
}