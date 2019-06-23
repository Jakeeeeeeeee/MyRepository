using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineGroceryStory;

namespace Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            int quantity = 40;
            string ItemId = "SH3";
            double expected = 35.92;
            OnlineOrder order = new OnlineOrder();

            //Act
            order.PlaceOrder(ItemId, quantity);

            //Assert
            double actual = order.Amount;
            Assert.AreEqual(expected, actual);
        }
    }
}
