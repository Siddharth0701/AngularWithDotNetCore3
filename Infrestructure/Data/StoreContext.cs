using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
namespace Infrestructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products{ get; set; }   
        public DbSet<ProductBrand>ProductBrands{ get; set; }   
        public DbSet<ProductType> ProductTypes { get; set; }

        
    }
}
