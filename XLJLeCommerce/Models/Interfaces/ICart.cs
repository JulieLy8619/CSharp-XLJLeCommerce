using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
    interface ICart
    {
        Task Create(Cart cart);
    }
}
