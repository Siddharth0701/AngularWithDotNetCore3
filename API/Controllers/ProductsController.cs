using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Infrestructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Threading.Tasks;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
       // private readonly StoreContext _context;
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo )
        {
            _repo = repo;
           // _context=context;
            
        }
        [HttpGet]
        public  async Task<ActionResult<List<Product>>> GetProducts(){
          var product=   await _repo.GetProductAsync();
            return Ok(product);

         //return "this will be list of products"; 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct( int id){
            return await _repo.GetProductByAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>>getproductBrands(){
            return Ok( await _repo.GetProductBrandAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>>getproductTypes(){
            return Ok( await _repo.GetProductTypeAsync());
        }


    }
}