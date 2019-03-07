using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Services;
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

        //create order
        [Fact]
        public async void TestCreateOrder()
        {
            DbContextOptions<CreaturesDbcontext> options = new DbContextOptionsBuilder<CreaturesDbcontext>().UseInMemoryDatabase("CreateOrder").Options;

            using (CreaturesDbcontext context = new CreaturesDbcontext(options))
            {

                Order testOrder5 = new Order();
                testOrder5.ID = 1;
                testOrder5.UserID = "aUserID";
                testOrder5.Totalprice = 30;

                OrderManagementService orderService = new OrderManagementService(context);

                await orderService.CreateOrder(testOrder5);

                var order1Answer = context.OrderTable.FirstOrDefault(c => c.ID == testOrder5.ID);

                Assert.Equal(testOrder5, order1Answer);
            }
        }

        //get order
        [Fact]
        public async void TestGetOrder()
        {
            DbContextOptions<CreaturesDbcontext> options = new DbContextOptionsBuilder<CreaturesDbcontext>().UseInMemoryDatabase("GetOrder").Options;

            using (CreaturesDbcontext context = new CreaturesDbcontext(options))
            {

                Order testOrder6 = new Order();
                testOrder6.ID = 1;
                testOrder6.UserID = "aUserID";
                testOrder6.Totalprice = 300;

                OrderManagementService orderService = new OrderManagementService(context);

                await orderService.CreateOrder(testOrder6);

                var order2Answer = await orderService.GetOrder("aUserID");

                Assert.Equal(testOrder6, order2Answer[0]);
            }
        }
    }
}
