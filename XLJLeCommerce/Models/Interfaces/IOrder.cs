using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
    public interface IOrder
    {
        //need to add orders
        Task CreateOrder(Order order);
        //i don't think we need to read orders (we would read ordered Items)
        //will we want to be able to update orders??? I vote no
        //we shouldn't delete orders


    }
}
