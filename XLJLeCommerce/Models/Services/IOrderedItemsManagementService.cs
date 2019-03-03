using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Models.Services
{
    public class IOrderedItemsManagementService : IOrderedItems
    {
        private CreaturesDbcontext _context { get; }

        public IOrderedItemsManagementService(CreaturesDbcontext context)
        {
            _context = context;
        }

        /// <summary>
        /// creates an ordered item
        /// </summary>
        /// <param name="orderedItems">the ordered item</param>
        /// <returns>the completed task after adding to the DB</returns>
        public async Task CreateOrderedItem(OrderedItems orderedItems)
        {
            _context.OrderedItemsTable.Add(orderedItems);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets all the ordered items in an order
        /// </summary>
        /// <param name="id">id for which order</param>
        /// <returns>ordered items in the order</returns>
            public async Task<List<OrderedItems>> GetAllOrderedItems(int id)
            {
                //gets the ordered items for the partic order
                var ordItems = from oi in _context.OrderedItemsTable
                            .Where(i => i.OrderID == id)
                                select oi;
                //gets the shopping cart items for this partic order
                foreach (OrderedItems ois in ordItems)
                {
                    var sci = from s in _context.ShoppingCartTable
                                where s.ID == ois.ShoppingCartItemID
                                select s;
                    ois.SCItems = await sci.ToListAsync();
                }

            return await ordItems.ToListAsync();
        }
    }
}
