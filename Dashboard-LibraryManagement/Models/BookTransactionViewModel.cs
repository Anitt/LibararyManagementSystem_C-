using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Models
{
    public class BookTransactionViewModel
    {

        [Required(ErrorMessage = "Enter book name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter author name")]
        public string Author { get; set; }

        public int MemberID { get; set; }

        public int BookID { get; set; }

        [Required(ErrorMessage = "Enter book status")]
        public string BookStatus { get; set; }

        [Required(ErrorMessage = "Enter the IssueDate")]
        public DateTime DateofIssue { get; set; }

        [Required(ErrorMessage = "Enter the DueDate")]
        public DateTime DueDate { get; set; }


    }
}