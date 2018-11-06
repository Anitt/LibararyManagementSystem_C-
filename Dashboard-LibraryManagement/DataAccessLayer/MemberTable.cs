using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Dashboard_LibraryManagement.DataAccessLayer
{
    public class MemberTable
    {
        private IDatabase database;
        public MemberTable() : this(new MySQLDatabase())
        {
        }


        public MemberTable(IDatabase database)
        {
            this.database = database;
        }

        /// Inserts a new library member in the LibMember table
        
        public int Insert(LibMember member)
        {
            string commandText = ProjectConstants.MemberInsert;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@memberid", member.MemberID);
            parameters.Add("@firstname", member.Firstname);
            parameters.Add("@lastname", member.Lastname);
            parameters.Add("@emailid", member.Email);
            parameters.Add("@phoneno", member.Phone);
            parameters.Add("@address", member.Address);
            parameters.Add("@dob", member.Dob);



            return database.Execute(commandText, parameters);
        }
   
        public int DeleteById(string MemberId)
        {
            string commandText = ProjectConstants.MemberDeleteById;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@memberid", MemberId);

            return database.Execute(commandText, parameters);
        }
        
        public int Delete(LibMember member)
        {
            return DeleteById(member.MemberID.ToString());
        }
       
        public int Update(LibMember member)
        {
            string commandText = ProjectConstants.MemberUpdate;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@memberid", member.MemberID);
            parameters.Add("@firstname", member.Firstname);
            parameters.Add("@lastname", member.Lastname);
            parameters.Add("@emailid", member.Email);
            parameters.Add("@phoneno", member.Phone);
            parameters.Add("@address", member.Address);
            parameters.Add("@dob", member.Dob);

            return database.Execute(commandText, parameters);
        }

        public IEnumerable<LibMember> GetMembers()
        {

            try
            {
                String commandText = ProjectConstants.MemberGetMembers;
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                List<Dictionary<string, string>> members = database.Query(commandText, parameters);
                List<LibMember> Memberdetails = new List<LibMember>();
                foreach (var member in members)
                {

                    LibMember libmember = new LibMember();
                    libmember.MemberID = Convert.ToInt32(member["Member_ID"]);
                    libmember.Firstname = member["First_Name"];
                    libmember.Lastname = member["Last_Name"];
                    libmember.Email = member["Email_id"];
                    libmember.Phone = member["Phone_no"];
                    libmember.Address = member["Address"];
                    libmember.Dob = member["DOB"];
                    Memberdetails.Add(libmember);

                }

                return Memberdetails;

            }
            catch (Exception)
            {

                throw;
            }

        }

         

        public LibMember GetMemberById(string memberid)
        {
            try
            {
                string commandText = ProjectConstants.MemberGetMemberById;
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@memberid", memberid);

                var member = database.Query(commandText, parameters).FirstOrDefault();
                if (member == null)
                    return null;

            
                LibMember libmember = new LibMember();
                libmember.MemberID = Convert.ToInt32(member["Member_ID"]);
                libmember.Firstname = member["First_Name"];
                libmember.Lastname = member["Last_Name"];
                libmember.Email = member["Email_id"];
                libmember.Phone = member["Phone_no"];
                libmember.Address = member["Address"];
                libmember.Dob = member["DOB"];

                return libmember;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
