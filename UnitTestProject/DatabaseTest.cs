using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityApplication.Entity;
using SecurityApplication.Model;
using SecurityApplication.Util;

namespace UnitTestProject
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void TestMethodFindAccountCorrect()
        {
            var database = new DatabaseAccount();
            string username = "nhanhtt";
            string password = "827ccb0eea8a706c4c34a16891f84e7b";

            var actual = database.FindAccount(username);
            var expected = new Account(username, password);

            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestMethodFindAccountWrong()
        {
            var database = new DatabaseAccount();
            string username = "nhanhtt";
            string password = "12345";

            var actual = database.FindAccount(username);
            var expected = new Account(username, password);

            Assert.IsFalse(actual.Equals(expected));
        }

        [TestMethod]
        public void TestMethodLoad_CountAccount()
        {
            var database = new DatabaseAccount();

            var actual = database.LoadAccount();
            var expected = database.CountAccount();

            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestMethodInsertCar()
        {
            var database = new DatabaseCar();
            var car = new Car("nhanhtt", "abc", "abc", "nhanhuynh", "12345");

            var actual = database.AddNewCar(car);
            Assert.IsTrue(actual);

            // Detele all
            database.TruncateTable(ConstantVariable.TableCar);
        }
    }
}
