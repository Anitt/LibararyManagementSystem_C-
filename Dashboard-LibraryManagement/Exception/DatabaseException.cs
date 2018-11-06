using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message, Exception exception) :base(message, exception)
        {
            message = " Database is down. \nError while accessing the database :" + message;
        }
    }
}