using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityApplication.Entity;
using SecurityApplication.Model;

namespace UnitTestProject
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void TestMethodFindAccountCorrect()
        {
            var database = new Database();
            string username = "nhanhtt";
            string password = "827ccb0eea8a706c4c34a16891f84e7b";

            var actual = database.FindAccount(username);
            var expected = new Account(username, password);

            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestMethodFindAccountWrong()
        {
            var database = new Database();
            string username = "nhanhtt";
            string password = "12345";

            var actual = database.FindAccount(username);
            var expected = new Account(username, password);

            Assert.IsFalse(actual.Equals(expected));
        }

        [TestMethod]
        public void TestMethodLoad_CountAccount()
        {
            var database = new Database();

            var actual = database.LoadAccount();
            var expected = database.CountAccount();

            Assert.AreEqual(expected, actual.Count);
        }
    }
}
