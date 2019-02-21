using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Interfaces
{
  public  interface Iproduct
    {
        //create product will add parameter later
        Task Create();

        //will add class later
        Task GetByID(int id);

        //will add IEnumerable<type> later
        Task GetAll();

        // Update Room will add parmeter later
        Task Update();

        // Delete Room
        Task Delete(int id);

    }
}
