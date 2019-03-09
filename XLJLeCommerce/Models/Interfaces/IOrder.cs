using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
    public interface IOrder
    {
        Task CreateOrder(Order order);
        Task<List<Order>> GetOrder(string id);
        Task<List<Order>> GetLastTenOrder();
    }
}
