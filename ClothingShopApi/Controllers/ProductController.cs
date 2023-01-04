using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClothingShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductController(IProductServices services)
        {
            _services= services;
        }
        // GET: api/<ProductController>
        [HttpGet("GetAllProducts")]
        public Task<List<Product>> GetAlls()
        {
            return _services.ViewListProduct();
        }

        // GET api/<ProductController>/5
        [HttpGet("FindProductByName/{productname}")]
        public Task<List<Product>> FindProductByName(string productname)
        {
            if (!string.IsNullOrEmpty(productname))
            {
               return _services.FindProductByName(productname);
            }
            else
            {
                return null;
            }
        }
        [HttpGet("GetProductDetail/{id}")]
        public async Task<Product> GetProduct(Guid id)
        {
            if (id!=null)
            {
                return await _services.ViewProduct(id);
            }
            else
            {
                return null;
            }
        }
        // POST api/<ProductController>
        [HttpPost]
        [Route("CreatProduct")]
        public async Task<bool> CreateProduct([FromBody] ProductModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
               result = await _services.CreateProduct(value);
            }
            return result;
        }

        // PUT api/<ProductController>/5
        [HttpPut("UpdateProduct/{id}")]
        public async Task<bool> UpdateProduct(Guid id, [FromBody] ProductModel value)
        {
            bool result = false;
            if (id!=null)
            {
               result = await _services.UpdateProduct(id,value);
            }
            return result;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<bool> Delete(Guid id)
        {
            bool result = false;
            if (id!= null)
            {
               result = await _services.DeleteProduct(id);
            }
            return result;
        }
    }
}
