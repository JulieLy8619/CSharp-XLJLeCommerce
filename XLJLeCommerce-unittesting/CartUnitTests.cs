using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Services;
using Xunit;

namespace XLJLeCommerce_unittesting
{
    public class CartUnitTests
    {
        //get userid
        [Fact]
        public void TestGetUserID()
        {
            Cart testCart1 = new Cart();
            testCart1.UserID = "goop";
            Assert.Equal("goop", testCart1.UserID);
        }

        //set user id
        [Fact]
        public void TestSetUserID()
        {
            Cart testCart2 = new Cart();
            testCart2.UserID = "goop";
            testCart2.UserID = "NewGoop";
            Assert.Equal("NewGoop", testCart2.UserID);
        }

        //create cart
        [Fact]
        public async void TestCreateCart()
        {
            DbContextOptions<CreaturesDbcontext> options = new DbContextOptionsBuilder<CreaturesDbcontext>().UseInMemoryDatabase("CreateCart").Options;

            using (CreaturesDbcontext context = new CreaturesDbcontext(options))
            {

                Cart testCart3 = new Cart();
                testCart3.ID = 1;
                testCart3.UserID = "aUserID";

                CartManagementService cartService = new CartManagementService(context);

                await cartService.Create(testCart3);

                var cart1Answer = context.Carts.FirstOrDefault(c => c.ID == testCart3.ID);

                Assert.Equal(testCart3, cart1Answer);
            }
        }

        //get cart
        [Fact]
        public async void TestReadCart()
        {
            DbContextOptions<CreaturesDbcontext> options = new DbContextOptionsBuilder<CreaturesDbcontext>().UseInMemoryDatabase("ReadCart").Options;

            using (CreaturesDbcontext context = new CreaturesDbcontext(options))
            {

                Cart testCart4 = new Cart();
                testCart4.ID = 1;
                testCart4.UserID = "aUserID";

                CartManagementService cartService = new CartManagementService(context);

                await cartService.Create(testCart4);

                var cart2Answer = await cartService.GetCart("aUserID");

                Assert.Equal(testCart4, cart2Answer);
            }
        }
    }
}
