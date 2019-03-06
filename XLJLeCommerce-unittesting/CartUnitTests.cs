using System;
using XLJLeCommerce.Models;
using Xunit;

namespace XLJLeCommerce_unittesting
{
    public class CartUnitTests
    {
        [Fact]
        public void TestGetUserID()
        {
            Cart testCart1 = new Cart();
            testCart1.UserID = "goop";
            Assert.Equal("goop", testCart1.UserID);
        }

        [Fact]
        public void TestSetUserID()
        {
            Cart testCart2 = new Cart();
            testCart2.UserID = "goop";
            testCart2.UserID = "NewGoop";
            Assert.Equal("NewGoop", testCart2.UserID);
        }

        //do I need to test the List "public List<ShoppingCartItem> CartItems {get;set;}"?
    }
}
