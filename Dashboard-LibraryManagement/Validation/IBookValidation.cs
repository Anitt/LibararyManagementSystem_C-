using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_LibraryManagement.Validation
{
   public interface IBookValidation
    {
       Boolean ValidateBook(Book newbook);
    }
}
