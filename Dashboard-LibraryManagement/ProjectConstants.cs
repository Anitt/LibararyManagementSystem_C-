using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement
{
    public class ProjectConstants
    {
        public const string BookDueDateDays = "BookDueDateDays";
        public const string Index = "Index";
        public const string Dashboard = "Dashboard";
        public const string Home = "Home";
        public const string Register = "Register";
        public const string SearchValue = "SearchValue";
        public const string Action = "action";
        public const string Clear = "Clear";
        public const string ListUser = "ListUser";
        public const string AddBook = "AddBook";
        public const string IssueBook = "IssueBook";
        public const string ListBook = "ListBook";
        public const string RenewBook = "RenewBook";
        public const string ReturnBook = "ReturnBook";
        public const string AddMember = "AddMember";
        public const string ListMember = "ListMember";
        public const string BookID = "@bookid";
        public const string BookName = "@name";
        public const string BookAuthor = "@author";
        public const string BookStatus = "@status";
        public const string BookPrice = "@price";
        public const string BookRackNo = "@rackno";
        public const string BookNoOfBooks = "@noofbooks";
        public const string TransactionID = "@transcationid";
        public const string MemberID = "@memberid";
        public const string DateOfIssue = "@dateofissue";
        public const string DueDate = "@duedate";
        public const string TransactionBookStatus = "@BookStatus";
        public const string transactionId = "@transasctionId";
        public const string KeyBookID = "Book_id";
        public const string KeyBookName = "Name";
        public const string KeyBookAuthor = "Author";
        public const string KeyBookStatus = "Status";
        public const string KeyBookRackNo = "Rack_No";
        public const string KeyBookNoOfBooks = "No_of_books";
        public const string KeyTransactionID = "Transcation_ID";


        public const string ListBookTranscation = "ListBooktranscation";
        public const string AppDescriptionPage = "Your application description page.";
        public const string ContactPage = "Your contact page.";
        public const string InvalidLoginMsg = "Username or Password is incorrect";
        public const string RegisterSuccessMsg = " successfully registered , Please Login";
        public const string RegisterFailMsg = "Registration failed , please try again !";
        public const string PasswordValidateFailMsg = "Validation of password Failed";
        public const string AddBookFailMsg = "Adding of Book Failed, Re-enter the details correctly";
        public const string SuccessMsg = "  successfully added !";
        public const string MemberExistingMsg = "The Member is already exisiting";
        public const string InvalidTransactionMsg = "Invalid Transaction Details";
        public const string MemberIdNotExistMsg = "Member Id does not exist.";

        public const string BookInsert = @"Insert into Book_Details (Book_id, Name, Author, Status,Price,Rack_No,No_of_books)
                values (@bookid, @name, @author, @status, @price, @rackno,@noofbooks)";
        public const string BookDeleteById = "Delete from Book_Details where Book_id = @bookid";
        public const string BookGetBooks = "Select * from Book_Details";
        public const string BookGetBookById = "Select * from Book_Details where Book_id = @bookid";
        public const string BookUpdate = @"Update Book_Details set Name = @name, Author = @author, Status = @status,Rack_no = @rackno , No_of_Books = @no_of_books
                    WHERE Book_id = @bookid";
        public const string BTInsert = @"Insert into Book_Transcation (Member_ID,Book_ID,Date_of_issue,Due_Date,BookStatus)
                values (@memberid, @bookid, @dateofissue,@duedate,@BookStatus)";
        public const string BTDeleteById = "Delete from Book_Transcation where Transcation_ID = @transcationid";
        public const string BTGetBooksForIssue = "Select * from Book_Details";
        public const string BTGetBookById = "Select * from Book_Transcation where Transcation_ID = @transasctionId";
        public const string BTGetBookByBookId = "Select * from Book_Transcation where Book_ID = @bookId";
        public const string BTGetBTCountByBookId = "Select * from Book_Transcation where Book_ID = @bookId";
        public const string BTRenewBook = @"Update Book_Transcation set Due_Date = @duedate,BookStatus = @BookStatus
                    WHERE Transcation_ID = @transcationid";
        public const string DashboardGetActiveBookTransaction = "Select * from Book_Transcation where BookStatus != '";
        public const string DashboardGetCountBooksIssued = "select count(BookStatus) as count from Book_Transcation where BookStatus in ('Renewed','Issued')";
        public const string DashboardGetCountBooksDue = "select count(Due_Date) as count from Book_Transcation where Due_Date = CURDATE()";
        public const string MemberInsert = @"Insert into Member_Details (Member_ID, First_Name, Last_Name, Email_id,Phone_no,Address,DOB)
                values (@memberid, @firstname, @lastname, @emailid,@phoneno,@address,@dob)";
        public const string MemberDeleteById = "Delete from Member_Details where Member_ID = @memberid";
        public const string MemberUpdate = @"Update Member_Details set First_Name = @firstname, Last_Name = @lastname, Email_id = @emailid , Phone_no = @phoneno , Address = @address , DOB = @dob
                    WHERE Member_ID = @memberid";
        public const string MemberGetMembers = "Select * from Member_Details";
        public const string MemberGetMemberById = "Select * from Member_Details where Member_ID = @memberid";
        public const string UserInsert = @"Insert into User_Details (ID, First_Name, Last_Name, Email_id,Password,Is_admin)
               values (@id, @firstname, @lastname, @emailid,@password,@isadmin)";
        public const string UserUpdate = @"Update User_Details set First_Name = @firstname, Last_Name = @lastname, Email_id = @emailid,Is_admin = @isadmin
                    WHERE ID = @userId";
        public const string UserGetUsers = "Select * from User_Details";
        public const string UserGetUserById = "Select * from User_Details where  ID = @userid";
        public const string UserGetUserByEmail = "Select * from User_Details where Email_id = @Email_id";

    }



}