using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter email")]
        [RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$", ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

		public string GetEmail() {
			return Email;
		}

		public void SetEmail(string email) {

			this.Email = email;
		}

		public string GetPassword() {

			return Password;
		}

		public void SetPassword(String password) {

			this.Password = password;
		}

		public bool GetRememberme() {

			return RememberMe;
		}

		public void SetRememberme(bool rememberme) {

			this.RememberMe = rememberme;
			
		}


    }
}