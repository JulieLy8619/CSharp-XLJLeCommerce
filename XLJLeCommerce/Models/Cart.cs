using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public List<ShoppingCartItem> CartItems {get;set;}
    }
}
