using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Models.Services
{
    public class OrderManagementService : IOrder
    {
        private CreaturesDbcontext _context { get; }
        /// <summary>
        /// OrderManagementService constructor by bringing in the creaturesDbcontext
        /// </summary>
        /// <param name="context"></param>
        public OrderManagementService(CreaturesDbcontext context)
        {
            _context = context;
        }

        /// <summary>
        /// creates an order
        /// </summary>
        /// <param name="order">the order</param>
        /// <returns>the task after it was added to the DB</returns>
        public async Task CreateOrder(Order order)
        {
            if (await _context.OrderTable.FirstOrDefaultAsync(c => c.ID == order.ID) == null)
            {
                _context.OrderTable.Add(order);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrder(string userid)
        {
            var orders = from ci in _context.OrderTable
                              .Where(i => i.UserID == userid)
                         select ci;


            return await orders.ToListAsync();
        }

    }
}
