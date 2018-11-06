using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Dashboard_LibraryManagement_UnitTest.DataAccessLayer
{
    [TestClass]
    public class UserTableTest
    {
        [TestMethod]
        public void Insert()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            UserTable usertable = new UserTable(mock.Object);
            UserAccount user = new UserAccount();
            user.SetFirstName("FName");
            user.SetLastName("LName");
            user.SetEmail("Email");
            user.SetPassword("Password");
            user.SetConfirmPassword("CPassword");
            user.SetAdmin(false);
            int result = usertable.Insert(user);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeletebyId()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            UserTable usertable = new UserTable(mock.Object);
            int result = usertable.DeleteById("25");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetUsersbyId_Null()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            UserTable usertable = new UserTable(mock.Object);
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.AreEqual(null, usertable.GetUsersById("1"));
        }

        [ExpectedException(typeof(KeyNotFoundException))]
        [TestMethod]
        public void GetUsersbyId_ExpectedException()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            UserTable usertable = new UserTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("test", "test");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            UserAccount user = new UserAccount();

            Assert.IsInstanceOfType(usertable.GetUsersById("1"), typeof(UserAccount));
        }

        [TestMethod]
        public void GetUsersbyId_Valid()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            UserTable usertable = new UserTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("ID", "10");
            parameter.Add("First_Name", "new");
            parameter.Add("Last_Name", "new");
            parameter.Add("Email_id", "new");
            parameter.Add("Password", "new");
            parameter.Add("Is_admin", "false");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            LibMember member = new LibMember();

            Assert.IsInstanceOfType(usertable.GetUsersById("1"), typeof(UserAccount));
        }

        [TestMethod]
        public void Update()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            UserTable usertable = new UserTable(mock.Object);
            UserAccount user = new UserAccount();
            user.SetFirstName("FName");
            user.SetLastName("LName");
            user.SetEmail("Email");
            user.SetPassword("Password");
            user.SetConfirmPassword("CPassword");
            user.SetAdmin(false);
            int result = usertable.Update(user);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetUsers()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            UserTable usertable = new UserTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            List<UserAccount> userlist = new List<UserAccount>();
            parameter.Add("ID", "10");
            parameter.Add("First_Name", "new");
            parameter.Add("Last_Name", "new");
            parameter.Add("Email_id", "new");
            parameter.Add("Password", "new");
            parameter.Add("Is_admin", "false");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            UserAccount user = new UserAccount();

            Assert.IsInstanceOfType(usertable.GetUsers(), typeof(List<UserAccount>));
        }
    }
}
