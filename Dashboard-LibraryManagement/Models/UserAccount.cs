using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dashboard_LibraryManagement.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Enter firstname")]
      //  [RegularExpression(@"[a-zA-Z]", ErrorMessage = "Invalid name format")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Enter lasttname")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Enter email")]
        [RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$", ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Enter username")]
        //public string Username { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public Boolean Isadmin { get; set; }

        public string GetUserName()
        {
            return string.Concat(Firstname, Lastname);
        }

        public int GetUserID() { return UserID; }
        public void SetUserID(int id) { this.UserID = id; }

        public string GetFirstname() { return Firstname; }
        public void SetFirstName(string firstname) { this.Firstname = firstname; }

        public string GetLastname() { return Lastname; }
        public void SetLastName(string lastname) { this.Lastname = lastname; }

        public string GetEmail() { return Email; }
        public void SetEmail(string email) { this.Email = email; }

        public string GetPassword() { return Password; }
        public void SetPassword(string password) { this.Password = password; }

        public string GetConfirmPassword() { return ConfirmPassword; }
        public void SetConfirmPassword(string confirm_password) { this.ConfirmPassword = confirm_password; }

        public Boolean GetAdmin() { return Isadmin; }
        public void SetAdmin(Boolean admin) { this.Isadmin = admin; }

    }
}