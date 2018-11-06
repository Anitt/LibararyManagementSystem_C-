using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Models
{
    public class DashBoardViewModel
    {
        public int countIssued { get; set; }

        public int countDuetoday { get; set; }

        public int countexpired { get; set; }

        public IEnumerable<BookTranscation> booksIssued { get; set; }

        public IEnumerable<BookTranscation> booksExpired { get; set; }
        public IEnumerable<BookTranscation> booksDueToday { get; set; }

    }
}