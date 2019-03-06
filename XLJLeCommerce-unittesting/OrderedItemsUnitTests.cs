using System;
using XLJLeCommerce.Models;
using Xunit;

namespace XLJLeCommerce_unittesting
{
    public class OrderedItemsUnitTests
    {
        [Fact]
        public void TestGetOrderID()
        {
            OrderedItems testOrderedItem1 = new OrderedItems();
            testOrderedItem1.OrderID = 1;
            Assert.Equal(1, testOrderedItem1.OrderID);
        }

        [Fact]
        public void TestSetOrderID()
        {
            OrderedItems testOrderedItem2 = new OrderedItems();
            testOrderedItem2.OrderID = 1;
            testOrderedItem2.OrderID = 100;
            Assert.Equal(100, testOrderedItem2.OrderID);
        }

        [Fact]
        public void TestGetShoppingCartItemID()
        {
            OrderedItems testOrderedItem3 = new OrderedItems();
            testOrderedItem3.ShoppingCartItemID = 1;
            Assert.Equal(1, testOrderedItem3.ShoppingCartItemID);
        }

        [Fact]
        public void TestSetShoppingCartItemID()
        {
            OrderedItems testOrderedItem4 = new OrderedItems();
            testOrderedItem4.ShoppingCartItemID = 1;
            testOrderedItem4.ShoppingCartItemID = 110;
            Assert.Equal(110, testOrderedItem4.ShoppingCartItemID);
        }

    }
}
