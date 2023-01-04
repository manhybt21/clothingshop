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
    public class ProductColorController : ControllerBase
    {
        private readonly IProductColorServices _services;
        public ProductColorController(IProductColorServices services)
        {
            _services = services;
        }
        // GET: api/<ProductColorController>
        [HttpGet("GetAllProductColor")]
        public async Task<List<ProductColor>> GetAllProductColor()
        {
            return await _services.ViewListProductColor();  
        }
        // POST api/<ProductColorController>
        [HttpPost("CreateProductColor")]
        public async Task<bool> CreateProductColor([FromBody] ProductColorModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
               result = await _services.CreateProductColor(value);
            }
            return result;
        }

        // PUT api/<ProductColorController>/5
        [HttpPut("UpdateProductColor/{id}")]
        public async Task<bool> UpdateProductColor(Guid id, [FromBody] ProductColorModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
               result = await _services.UpdateProductColor(id,value);
            }
            return result;
        }

        // DELETE api/<ProductColorController>/5
        [HttpDelete("DeleteProductColor/{id}")]
        public async Task<bool> DeleteProductColor(Guid id)
        {
            bool result = false;
            if (id!=null)
            {
               result = await _services.DeleteProductColor(id);
            }
            return result;
        }
    }
}
