using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
    public interface ICart
    {
        Task Create(Cart cart);
        //we won't need to update the cart (we decided only one cart per user, and we wouldn't transfer a cart to another user)
        //we won't need to delete a cart (we would "Delete" the shoppingcartitem that would be in the cart)
        //we won't need to read a cart (we call shoppingcartitem's get all items)
    }
}
