using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public decimal Totalprice { get; set; }
        public List<OrderedItems> OrderedItems { get; set; }
    }
}
