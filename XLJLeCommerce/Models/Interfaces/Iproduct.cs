using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
  public  interface Iproduct
    {
        //create product will add parameter later
        Task Create(Product product);

        //will add class later
        Task<Product> GetProduct(int id);

        //will add IEnumerable<type> later
        Task<List<Product>> GetAllProducts();

        // Update 
        Task UpdateProduct(Product product);

        // Delete 
        Task DeleteProduct(int id);

    }
}
