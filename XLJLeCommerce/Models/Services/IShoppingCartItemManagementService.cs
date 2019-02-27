using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Models.Services
{
    public class IShoppingCartItemManagementService : IShoppingCartItem
    {
        /// <summary>
        /// creates an item to add to the shopping cart
        /// </summary>
        /// <param name="shoppingCartItem">takes in a showpping cart item</param>
        /// <returns>the completed service of adding it to the DB</returns>
        public Task Create(ShoppingCartItem shoppingCartItem)
        {
            throw new NotImplementedException();
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
        /// gets all shopping cart items
        /// </summary>
        /// <returns>a list of the shopping cart items</returns>
        public Task<List<ShoppingCartItem>> GetAllShoppingCartItems()
        {
            throw new NotImplementedException();
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
