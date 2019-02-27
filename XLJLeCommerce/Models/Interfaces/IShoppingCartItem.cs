using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
    interface IShoppingCartItem
    {
        Task CreateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        Task<ShoppingCartItem> GetShoppingCartItem(int id);
        Task<List<ShoppingCartItem>> GetAllShoppingCartItems();
        Task UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        Task DeleteShoppingCartItem(int id);
    }
}
