using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Models
{
    public class BookTranscation
    {

        [Key]
        public int TranscationID { get; set; }

        public int MemberID { get; set; }

        public int BookID { get; set; }

        [Required(ErrorMessage = "Enter book status")]
        public string BookStatus { get; set; }

        [Required(ErrorMessage = "Enter the IssueDate")]
        public DateTime DateofIssue { get; set; }

        [Required(ErrorMessage = "Enter the DueDate")]
        public DateTime DueDate { get; set; }

		public int GetTranscationID() {

			return TranscationID;
		}

		public void SetTranscationID(int id) {

			this.TranscationID = id;
		}

		public int GetMemberID()
		{

			return MemberID;
		}

		public void SetMemberID(int id)
		{

			this.MemberID = id;
		}

		public int GetBookID()
		{

			return BookID;
		}

		public void SetBookID(int id)
		{

			this.BookID = id;
		}


		public String GetBookStatus()
		{

			return BookStatus;
		}

		public void SetBookStatus(String status)
		{

			this.BookStatus = status;
		}

		
		public DateTime GetDateofissue()
		{

			return DateofIssue;
		}

		public void SetDateofissue(DateTime date)
		{

			this.DateofIssue = date;
		}


		public DateTime GetDueDate()
		{

			return DueDate;
		}

		public void SetDueDate(DateTime date)
		{

			this.DueDate = date;
		}



	}
}