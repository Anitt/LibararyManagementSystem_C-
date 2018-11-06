using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_LibraryManagement.Validation
{
  public interface IUserValidation
    {
        Boolean ValidateUser(string Email, string password, out UserAccount userAccount);
    }
}
