using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
    public interface ICart
    {
        Task Create(Cart cart);
        Task<Cart> GetCart(string userid);

    }
}
