using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityApplication.Entity;

namespace UnitTestProject
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void TestMethodCompareCarHostNameExist()
        {
            Car car1 = new Car("nhanhtt", "abc", "abc", "nhanhuynh", "12345");
            Car car2 = new Car("nhanhtt", "abc", "abc", "nhanhuynh", "12345");
            int actual = car1.CompareCar(car2);
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodCompareCarUserNameExist()
        {
            Car car1 = new Car("nhanhtt", "abc", "abc", "nhanhuynh", "12345");
            Car car2 = new Car("nhanhtt", "ncc", "abc", "nhanhuynh", "12345");
            int actual = car1.CompareCar(car2);
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodCompareCarAccept()
        {
            Car car1 = new Car("nhanhtt", "abc", "abc", "nhanhuynh", "12345");
            Car car2 = new Car("nhanhtt", "ncc", "bac", "aaa", "12345");
            int actual = car1.CompareCar(car2);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}
