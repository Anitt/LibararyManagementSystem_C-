using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_LibraryManagement.DataAccessLayer
{
    interface IUserTable
    {
        // To insert a user record into the usertable
        int Insert(UserAccount user);
        // To Delete a userid from the usertable 
        int Delete(string userId);
        //to delete a user from the user table
        int Delete(UserAccount user);
        //to update a user to the user table
        int Update(UserAccount user);




    }
}
