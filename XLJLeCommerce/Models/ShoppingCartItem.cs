using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models
{
    public class ShoppingCartItem
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int ProdQty { get; set; }
  
        //navigation
        public Cart Cart { get; set; }
        public ICollection<Product> Prod { get; set; }
        public Product Product { get; set; }
    }
}
