using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Models.Services
{
    public class IproductManagementService : Iproduct
    {


        private CreaturesDbcontext _context { get; }

        public IproductManagementService(CreaturesDbcontext context)
        {
            _context = context;
        }
        public Task Create()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
