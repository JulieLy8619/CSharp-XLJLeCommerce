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

        public async Task<List<Order>> GetLastTenOrder()
        {
            var orders = (from o in _context.OrderTable
                              orderby o.ID descending
                         select o).Take(10);

            foreach (Order o in orders)
            {
                var ordItems = from oi in _context.OrderedItemsTable
                            .Where(i => i.OrderID == o.ID)
                               select oi;
                o.OrderedItems = await ordItems.ToListAsync();

                foreach (OrderedItems oi in ordItems)
                {
                    var prods = from p in _context.Products
                                where p.ID == oi.ProductID
                                select p;
                    oi.Prod = await prods.ToListAsync();

                }

                //foreach (OrderedItems ois in ordItems)
                //{
                //    var sci = from s in _context.ShoppingCartTable
                //              where s.ID == ois.ShoppingCartItemID
                //              select s;
                //    ois.SCItems = await sci.ToListAsync();

                //    foreach (ShoppingCartItem si in sci)
                //    {
                //        var prods = from p in _context.Products
                //                    where p.ID == si.ProductID
                //                    select p;
                //        si.Prod = await prods.ToListAsync();

                //    }
                //}
            }

            return await orders.ToListAsync();
        }

    }
}
