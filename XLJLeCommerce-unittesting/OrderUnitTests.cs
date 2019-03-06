using System;
using XLJLeCommerce.Models;
using Xunit;

namespace XLJLeCommerce_unittesting
{
    public class OrderUnitTests
    {
        [Fact]
        public void TestGetUserID()
        {
            Order testOrder1 = new Order();
            testOrder1.UserID = "aUserID";
            Assert.Equal("aUserID", testOrder1.UserID);
        }

        [Fact]
        public void TestSetUserID()
        {
            Order testOrder2 = new Order();
            testOrder2.UserID = "aUserID";
            testOrder2.UserID = "NewUserID";
            Assert.Equal("NewUserID", testOrder2.UserID);
        }

        [Fact]
        public void TestGetTotalPrice()
        {
            Order testOrder3 = new Order();
            testOrder3.Totalprice = 3;
            Assert.Equal(3, testOrder3.Totalprice);
        }

        [Fact]
        public void TestSetTotalPrice()
        {
            Order testOrder4 = new Order();
            testOrder4.Totalprice = 3;
            testOrder4.Totalprice = 300;
            Assert.Equal(300, testOrder4.Totalprice);
        }

        //Do I need to test the List "public List<OrderedItems> OrderedItems { get; set; }"
    }
}
