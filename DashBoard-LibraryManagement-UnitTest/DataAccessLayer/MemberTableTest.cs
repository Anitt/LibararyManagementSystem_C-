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
    public class MemberTableTest
    {
        [TestMethod]
        public void Insert()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            MemberTable membertable = new MemberTable(mock.Object);
            LibMember member = new LibMember();
            member.SetFirstname("Renu");
            member.SetLastname("Damodaran");
            member.SetEmail("renu@gmail.com");
            member.SetPhone("9024012836");
            member.SetAddress("1144 Quingate Street");
            member.SetDob("20-05-1992");
            int result = membertable.Insert(member);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeletebyId()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            MemberTable membertable = new MemberTable(mock.Object);
            int result = membertable.DeleteById("25");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Update()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            MemberTable membertable = new MemberTable(mock.Object);
            LibMember member = new LibMember();
            member.SetFirstname("Renu");
            member.SetLastname("Damodaran");
            member.SetEmail("renu@gmail.com");
            member.SetPhone("9024012836");
            member.SetAddress("1144 Quingate Street");
            member.SetDob("20-05-1992");
            int result = membertable.Update(member);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetMemberbyId_Null()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            MemberTable membertable = new MemberTable(mock.Object);
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.AreEqual(null, membertable.GetMemberById("1"));
        }

        [ExpectedException(typeof(KeyNotFoundException))]
        [TestMethod]
        public void GetMemberbyId_ExpectedException()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            MemberTable membertable = new MemberTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("test", "case");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            LibMember member = new LibMember();

            Assert.IsInstanceOfType(membertable.GetMemberById("1"), typeof(LibMember));
        }

        [TestMethod]
        public void GetMemberbyId_Valid()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            MemberTable membertable = new MemberTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Member_ID", "90");
            parameter.Add("First_Name", "case");
            parameter.Add("Last_Name", "case");
            parameter.Add("Email_id", "case");
            parameter.Add("Phone_no", "case");
            parameter.Add("Address", "case");
            parameter.Add("DOB", "case");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            LibMember member = new LibMember();

            Assert.IsInstanceOfType(membertable.GetMemberById("1"), typeof(LibMember));
        }

        [TestMethod]
        public void GetMembers()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            MemberTable membertable = new MemberTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Member_ID", "90");
            parameter.Add("First_Name", "case");
            parameter.Add("Last_Name", "case");
            parameter.Add("Email_id", "case");
            parameter.Add("Phone_no", "case");
            parameter.Add("Address", "case");
            parameter.Add("DOB", "case");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            
            Assert.IsInstanceOfType(membertable.GetMembers(), typeof(List<LibMember>));
        }






    }
}
