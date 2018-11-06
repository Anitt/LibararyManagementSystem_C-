using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dashboard_LibraryManagement.Models
{
    public class LibMember
    {
        [Key]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Enter member first name")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Invalid name format")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Enter member last name")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Invalid name format")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Enter member email")]
        [RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$", ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter phone number")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Invalid number format")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter date of birth")]
        public String Dob { get; set; }


        public int GetMemberID() { return MemberID; }
        public void SetMemberID(int id) { this.MemberID = id; }

        public String GetFirstname() { return Firstname; }
        public void SetFirstname(string firstname) { this.Firstname = firstname; }

        public String GetLastname() { return Lastname; }
        public void SetLastname(string lastname) { this.Lastname = lastname; }

        public String GetEmail() { return Email; }
        public void SetEmail(string email) { this.Email = email; }

        public String GetPhone() { return Phone; }
        public void SetPhone(string phone) { this.Phone = phone; }

        public String GetAddress() { return Address; }
        public void SetAddress(string address) { this.Address = address; }

        public String GetDob() { return Dob; }
        public void SetDob(string dob) { this.Dob = dob; }
    }
}