using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Services;
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

        //create ordered items
        [Fact]
        public async void TestCreateOrdereItems()
        {
            DbContextOptions<CreaturesDbcontext> options = new DbContextOptionsBuilder<CreaturesDbcontext>().UseInMemoryDatabase("CreateOrderedItems").Options;

            using (CreaturesDbcontext context = new CreaturesDbcontext(options))
            {

                OrderedItems testOrderedItem5 = new OrderedItems();
                testOrderedItem5.ID = 1;
                testOrderedItem5.OrderID = 1;
                testOrderedItem5.ShoppingCartItemID = 1;

                OrderedItemsManagementService orderedItemsService = new OrderedItemsManagementService(context);

                await orderedItemsService.CreateOrderedItem(testOrderedItem5);

                var orderedItems1Answer = context.OrderedItemsTable.FirstOrDefault(c => c.ID == testOrderedItem5.ID);

                Assert.Equal(testOrderedItem5, orderedItems1Answer);
            }
        }

        //get all ordered items
        [Fact]
        public async void TestGetAllOrdereItems()
        {
            DbContextOptions<CreaturesDbcontext> options = new DbContextOptionsBuilder<CreaturesDbcontext>().UseInMemoryDatabase("GetAllOrderedItems").Options;

            using (CreaturesDbcontext context = new CreaturesDbcontext(options))
            {

                OrderedItems testOrderedItem6 = new OrderedItems();
                testOrderedItem6.ID = 1;
                testOrderedItem6.OrderID = 1;
                testOrderedItem6.ShoppingCartItemID = 1;

                OrderedItems testOrderedItem7 = new OrderedItems();
                testOrderedItem7.ID = 2;
                testOrderedItem7.OrderID = 1;
                testOrderedItem7.ShoppingCartItemID = 5;

                OrderedItemsManagementService orderedItemsService = new OrderedItemsManagementService(context);

                await orderedItemsService.CreateOrderedItem(testOrderedItem6);
                await orderedItemsService.CreateOrderedItem(testOrderedItem7);

                var orderedItems2Answer = await orderedItemsService.GetAllOrderedItems(1);

                Assert.Equal(2, orderedItems2Answer.Count);
            }
        }

    }
}
