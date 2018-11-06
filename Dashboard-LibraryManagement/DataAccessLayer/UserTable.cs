using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using System.Web;
using Dashboard_LibraryManagement.DataAccessLayer;

namespace Dashboard_LibraryManagement.Models
{ 

public class UserTable
{
        private IDatabase _database;
        public UserTable() : this(new MySQLDatabase())
        {
        }

        // adding a log
        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public UserTable(IDatabase database)
    {
        _database = database;
    }

    public int Insert(UserAccount user)
    {
            // To register a user to user table'

           // String commandText = "sproc_insert_userdetails";

        string commandText = ProjectConstants.UserInsert;
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("@id", user.UserID);
        parameters.Add("@firstname", user.Firstname);
        parameters.Add("@lastname", user.Lastname);
        parameters.Add("@emailid", user.Email);
        parameters.Add("@password", user.Password);
        parameters.Add("@isadmin", user.Isadmin);

            log.Info("Registration of user in the application");
        return _database.Execute(commandText, parameters);
    }
    public int DeleteById(string userId)
    {
        string commandText = "Delete from User_Details where ID = @userId";
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("@userId", userId);

            log.Info("Deletion of a user from the application");
            return _database.Execute(commandText, parameters);
    }
    public int Delete(UserAccount user)
    {
        return DeleteById(user.UserID.ToString());
    }
    public int Update(UserAccount user)
    {
        string commandText =ProjectConstants.UserUpdate;
        Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@userId", user.UserID);
            parameters.Add("@firstname", user.Firstname);
            parameters.Add("@lastname", user.Lastname);
            parameters.Add("@emailid", user.Email);
            parameters.Add("@password", user.Password);
            parameters.Add("@isadmin", user.Isadmin);

            log.Info("Updating the user in the usertable");

            return _database.Execute(commandText, parameters);
    }


        public IEnumerable<UserAccount> GetUsers()
        {
            try
            {   
                string commandText = ProjectConstants.UserGetUsers;
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                List<Dictionary<string, string>> Listofusers = _database.Query(commandText, parameters);
                List<UserAccount> userlist = new List<UserAccount>();
                foreach (var user in Listofusers)
                {
                    UserAccount useraccount = new UserAccount();
                    useraccount.UserID = Convert.ToInt32(user["ID"]);
                    useraccount.Firstname = user["First_Name"];
                    useraccount.Lastname = user["Last_Name"];
                    useraccount.Email = user["Email_id"];
                    useraccount.Password = user["Password"];
                    useraccount.Isadmin = Convert.ToBoolean(user["Is_admin"]);
                    userlist.Add(useraccount);
                }
                return userlist;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserAccount GetUsersById(string UserId)
        {
            try
            {
                string commandText = ProjectConstants.UserGetUserById;
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@userid", UserId);

          
                var user = _database.Query(commandText, parameters).FirstOrDefault();
                if (user == null)
                    return null;

                UserAccount currentuser = new UserAccount();
                currentuser.UserID = Convert.ToInt32(user["ID"]);
                currentuser.Firstname = user["First_Name"];
                currentuser.Lastname = user["Last_Name"];
                currentuser.Email = user["Email_id"];
                currentuser.Password = user["Password"];
                currentuser.Isadmin = Convert.ToBoolean(user["Is_admin"]);

                return currentuser;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserAccount GetUsersByEmailId(string emailId)
        {
            try
            {
                string commandText = ProjectConstants.UserGetUserByEmail;
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@Email_id", emailId);


                var user = _database.Query(commandText, parameters).FirstOrDefault();
                if (user == null)
                    return null;

                UserAccount currentuser = new UserAccount();
                currentuser.UserID = Convert.ToInt32(user["ID"]);
                currentuser.Firstname = user["First_Name"];
                currentuser.Lastname = user["Last_Name"];
                currentuser.Email = user["Email_id"];
                currentuser.Password = user["Password"];
                currentuser.Isadmin = Convert.ToBoolean(user["Is_admin"]);

                return currentuser;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
