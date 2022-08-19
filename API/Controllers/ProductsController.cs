using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Infrestructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context=context;
            
        }
        [HttpGet]
        public  async Task<ActionResult<List<Product>>> GetProducts(){
          var product=   await _context.Products.ToListAsync();
            return Ok(product);

         //return "this will be list of products"; 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct( int id){
            return await _context.Products.FindAsync(id);
        }
        

    }
}