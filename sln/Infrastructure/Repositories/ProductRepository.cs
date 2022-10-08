using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
        public async Task SaveProduct(Product product)
        {


            base.Add(product);
           await _unitOfWork.Complete();
        }
    }


  
}