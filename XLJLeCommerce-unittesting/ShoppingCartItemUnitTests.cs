using Microsoft.EntityFrameworkCore;
using System;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Services;
using Xunit;

namespace XLJLeCommerce_unittesting
{
    public class ShoppingCartItemUnitTests
    {/// <summary>
    /// getter ID
    /// </summary>
        [Fact]
        public void getterID()
        {
            ShoppingCartItem s = new ShoppingCartItem();
            s.ID = 1;
            Assert.True(s.ID == 1);
        }
        /// <summary>
        /// setter
        /// </summary>
        [Fact]
        public void SetterID()
        {
            ShoppingCartItem s = new ShoppingCartItem();
            s.ID = 1;
            s.ID = 11;
            Assert.True(s.ID == 11);
        }
        /// <summary>
        /// getter-cartID
        /// </summary>
        [Fact]
        public void getterCartID()
        {
            ShoppingCartItem s = new ShoppingCartItem();
            s.CartID = 1;
            Assert.True(s.CartID == 1);
        }

        /// <summary>
        /// setter-cartID
        /// </summary>
        [Fact]
        public void SetterCartID()
        {
            ShoppingCartItem s = new ShoppingCartItem();
            s.CartID = 1;
             s.CartID = 11;
            Assert.True(s.CartID == 11);
        }

        /// <summary>
        /// getter-productID
        /// </summary>
        [Fact]
        public void getterProID()
        {
            ShoppingCartItem s = new ShoppingCartItem();
            s.ProductID = 1;
            Assert.True(s.ProductID == 1);
        }
        /// <summary>
        /// setter-productID
        /// </summary>
        [Fact]
        public void setterProID()
        {
            ShoppingCartItem s = new ShoppingCartItem();
            s.ProductID = 1;
            s.ProductID = 11;
            Assert.True(s.ProductID ==11);
        }


        /// <summary>
        /// getter-quantity
        /// </summary>
        [Fact]
        public void getterquan()
        {
            ShoppingCartItem s = new ShoppingCartItem();
            s.ProdQty = 1;
            Assert.True(s.ProdQty== 1);
        }


        /// <summary>
        /// setter-quan
        /// </summary>
        [Fact]
        public void setterquan()
        {
            ShoppingCartItem s = new ShoppingCartItem();
            s.ProdQty = 1;
            s.ProdQty = 11;
            Assert.True(s.ProdQty == 11);
        }


        /// <summary>
        /// CreateShoppingCartItem
        /// </summary>
        [Fact]
         public async void cancreateshoppingcartitem()
        {
            DbContextOptions<CreaturesDbcontext> options = new DbContextOptionsBuilder<CreaturesDbcontext>().UseInMemoryDatabase("CreateShoppingcartItems").Options;

            using (CreaturesDbcontext context = new CreaturesDbcontext(options))
            {

               ShoppingCartItem si = new ShoppingCartItem();
                si.ID = 1;

                ShoppingCartItemManagementService Service = new ShoppingCartItemManagementService(context);

                await Service.CreateShoppingCartItem(si);

                var expect =await context.ShoppingCartTable.FirstOrDefaultAsync(c => c.ID == si.ID);

                Assert.Equal(expect, si);
            }

        }
    }
}
