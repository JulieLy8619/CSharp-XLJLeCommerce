using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Models.Services
{
    public class ICartManagementService : ICart
    {
        private CreaturesDbcontext _context { get; }
        /// <summary>
        /// ICartManagementService Constructor by taking in the CreaturesDbcontext
        /// </summary>
        /// <param name="context"></param>
        public ICartManagementService(CreaturesDbcontext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a cart
        /// </summary>
        /// <param name="cart">the cart</param>
        /// <returns>a task</returns>
        public async Task Create(Cart cart)
        {
            if (await _context.Carts.FirstOrDefaultAsync(c => c.ID == cart.ID) == null)
            {
                _context.Carts.Add(cart);
            }
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// get one cart by taking in the userID since each user has one Cart.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task<Cart> GetCart(string userid)
        {
            var carts = await _context.Carts.FirstOrDefaultAsync(i => i.UserID == userid);

            return carts;
        }
    }
}
