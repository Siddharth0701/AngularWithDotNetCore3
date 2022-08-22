using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrestructure.Data
{
    public class ProductRepository:IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
            
        }
         public async Task<Product>GetProductByAsync( int id){
            return await _context.Products.FindAsync(id);

         }
       public async Task<IReadOnlyList<Product>>GetProductAsync(){
        return await _context.Products.ToListAsync();

        }
        
    }
}