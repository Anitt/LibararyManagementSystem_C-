using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dashboard_LibraryManagement.Models
{
    public class Book
    {

        [Key]
        public int BookID { get; set; }

        [Required(ErrorMessage = "Enter book name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter author name")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Enter book status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Enter the Price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Enter book rack")]
        public int Rackno { get; set; }

        [Required(ErrorMessage = "Enter book count")]
        public int Count { get; set; }


        public int GetBookID() { return BookID; }
        public void SetBookID(int id) { this.BookID = id; }

        public string GetName() { return Name; }
        public void SetName(string name) { this.Name = name; }

        public string GetAuthor() { return Author; }
        public void SetAuthor(string author) { this.Author = author; }

        public string GetStatus() { return Status; }
        public void SetStatus(string status) { this.Status = status; }

        public int GetPrice() { return Price; }
        public void SetPrice(int price) { this.Price = price; }

        public int GetRackno() { return Rackno; }
        public void SetRackno(int rackno) { this.Rackno = rackno; }

        public int GetCount() { return Count; }
        public void SetCount(int count) { this.Count = count; }

    }
}