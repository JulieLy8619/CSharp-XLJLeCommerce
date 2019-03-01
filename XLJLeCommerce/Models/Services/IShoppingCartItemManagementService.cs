using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Models.Services
{
    public class IShoppingCartItemManagementService : IShoppingCartItem
    {
        private CreaturesDbcontext _context { get; }

        public IShoppingCartItemManagementService(CreaturesDbcontext context)
        {
            _context = context;
        }
        /// <summary>
        /// creates an item to add to the shopping cart
        /// </summary>
        /// <param name="shoppingCartItem">takes in a showpping cart item</param>
        /// <returns>the completed service of adding it to the DB</returns>
        public async Task CreateShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            _context.ShoppingCartTable.Add(shoppingCartItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// deletes a shopping cart item
        /// </summary>
        /// <param name="id">which item to delete</param>
        /// <returns>the task it was complete and delete from database</returns>
        public Task DeleteShoppingCartItem(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// gets all the shopping cart items from one cart
        /// </summary>
        /// <param name="id">which cart</param>
        /// <returns>the items in specific cart</returns>
        public async Task<IEnumerable<ShoppingCartItem>> GetAllShoppingCartItems(int id)
        {
            var cartItems = from ci in _context.ShoppingCartTable
                            .Where(i => i.CartID == id)
                            select ci;

            foreach (ShoppingCartItem sci in cartItems)
            {
                var prods = from p in _context.Products
                           where p.ID == sci.ProductID
                           select p;
                sci.Prod = await prods.ToListAsync();
            }

            return await cartItems.ToListAsync();
        }

        /// <summary>
        /// gets just one item shopping cart item
        /// </summary>
        /// <param name="id">which item</param>
        /// <returns>the item</returns>
        public Task<ShoppingCartItem> GetShoppingCartItem(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// updates the shopping cart item
        /// </summary>
        /// <param name="shoppingCartItem">the shoping cart item</param>
        /// <returns>the compelted task that it updated the database</returns>
        public Task UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            throw new NotImplementedException();
        }
    }
}
