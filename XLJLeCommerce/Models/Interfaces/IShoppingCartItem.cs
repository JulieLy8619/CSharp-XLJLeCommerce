using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
    public interface IShoppingCartItem
    {
        //adds an item to the cart
        Task CreateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        //gets one specific item from the cart
        Task<ShoppingCartItem> GetShoppingCartItem(int id);
        //gets all the items in the cart
        Task<IEnumerable<ShoppingCartItem>> GetAllShoppingCartItems(int id);
        //updates one item in the cart
        Task UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        //deletes an item from the cart
        Task DeleteShoppingCartItem(int id);
    }
}
