using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
    public interface IOrderedItems
    {
        //need to be able to add ordered items
        Task CreateOrderedItem(OrderedItems orderedItems);
        //need to be able to read all ordered items
        Task<IEnumerable<OrderedItems>> GetAllOrderedItems(int id);

        //we shouldn't be able to delete ordered items
        //we shouldn't be able to udpate ordered items
    }
}
