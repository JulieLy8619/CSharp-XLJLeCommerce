using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models
{
    public class OrderedItems
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ShoppingCartItemID { get; set; }


        //naviagtion
        public Order Order { get; set; }
        public Cart Cart { get; set; }
        public ICollection<ShoppingCartItem> SCItems { get; set; }
        public ShoppingCartItem ShoppingCartItem { get; set; }

    }
}
