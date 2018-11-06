using Dashboard_LibraryManagement.PasswordValidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_LibraryManagement.Interfaces
{
    public interface IPassword
    {
        IPassword CheckNextProp(IPassword nextProp);
        bool checkPassword(PropertyCheck password);
    }
}
