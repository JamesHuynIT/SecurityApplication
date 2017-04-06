using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityApplication.Entity;

namespace UnitTestProject
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void TestMethodCompareAccountWrongPassword()
        {
            Account account1 = new Account("nhanhtt", "12345");
            Account account2 = new Account("nhanhtt", "1234");
            int actual = account1.CompareAccount(account2);
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodCompareAccountCorrect()
        {
            Account account1 = new Account("nhanhtt", "12345");
            Account account2 = new Account("nhanhtt", "12345");
            int actual = account1.CompareAccount(account2);
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodCompareAccountNotExist()
        {
            Account account1 = new Account("nhanhtt", "12345");
            Account account2 = new Account("", "12345");
            int actual = account1.CompareAccount(account2);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodCompareAccountWrong()
        {
            Account account1 = new Account();
            Account account2 = new Account("nhanhtt", "12345");
            int actual = account1.CompareAccount(account2);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}
