using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;
using Core.Entities;
using System.Text.Json;

namespace Infrestructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.Productbrands.Any()){
                    var brandData=File.ReadAllText("../Infrestructure/Data/SeedData/brands.json");
                    var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.ProductTypes.Any()){
                    var typeData=File.ReadAllText("../Infrestructure/Data/SeedData/types.json");
                    var types=JsonSerializer.Deserialize<List<ProductType>>(typeData);
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.Product.Any()){
                    var productsData=File.ReadAllText("../Infrestructure/Data/SeedData/products.json");
                    var products=JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                
                var logger =loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
        
    }
}