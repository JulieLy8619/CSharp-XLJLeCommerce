using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Data
{
    public class CreaturesDbcontext: DbContext
    {
        public CreaturesDbcontext(DbContextOptions<CreaturesDbcontext> options) : base(options){

        }




    }
}
