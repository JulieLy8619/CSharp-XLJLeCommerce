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
        /// 
        /// </summary>
        /// <param name="shoppingCartItem"></param>
        /// <returns></returns>
        public Task Create(ShoppingCartItem shoppingCartItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteShoppingCartItem(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<ShoppingCartItem>> GetAllShoppingCartItems()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ShoppingCartItem> GetShoppingCartItem(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shoppingCartItem"></param>
        /// <returns></returns>
        public Task UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            throw new NotImplementedException();
        }
    }
}
