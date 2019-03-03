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
        public Task CreateOrderedItem(OrderedItems orderedItems)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// gets all the ordered items in an order
        /// </summary>
        /// <param name="id">id for which order</param>
        /// <returns>ordered items in the order</returns>
        public Task<IEnumerable<OrderedItems>> GetAllOrderedItems(int id)
        {
            throw new NotImplementedException();
        }
    }
}
