using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Models
{
    public enum BookTransactionStatus
    {
       Issued =1,
       Renewed =2,
       Returned = 3

    }

    public enum BookStatus
    {
        Available=0,
        NotAvailable=1
    }
}