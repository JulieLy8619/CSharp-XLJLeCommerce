using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProdID { get; set; }
        public int ProdQty { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
