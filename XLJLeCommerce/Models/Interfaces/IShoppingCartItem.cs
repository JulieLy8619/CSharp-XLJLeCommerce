using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
    public interface IShoppingCartItem
    {
        Task CreateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        Task<ShoppingCartItem> GetShoppingCartItem(int id);
        Task<IEnumerable<ShoppingCartItem>> GetAllShoppingCartItems(int id);
        Task UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        Task DeleteShoppingCartItem(int id);
    }
}
