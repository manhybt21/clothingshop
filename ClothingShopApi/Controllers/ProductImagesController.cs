using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClothingShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageServices _services;
        public ProductImagesController(IProductImageServices services)
        {
            _services = services;
        }
        // GET: api/<ProductColorController>
        [HttpGet("GetAllProductImages")]
        public async Task<List<ProductImage>> GetAllProductColor()
        {
            return await _services.ViewListProductImage();
        }
        // POST api/<ProductColorController>
        [HttpPost("CreateProductImage")]
        public async Task<bool> CreateProductImage([FromBody] ProductImageModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = await _services.CreateProductImage(value);
            }
            return result;
        }

        // PUT api/<ProductColorController>/5
        [HttpPut("UpdateProductImage/{id}")]
        public async Task<bool> UpdateProductImage(Guid id, [FromBody] ProductImageModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
               result = await _services.UpdateProductImage(id, value);
            }
            return result;
        }

        // DELETE api/<ProductColorController>/5
        [HttpDelete("DeleteProductImage/{id}")]
        public async Task<bool> DeleteProductImage(Guid id)
        {
            bool result = false;
            if (id != null)
            {
               result =await _services.DeleteProductImage(id);
            }
            return result;
        }
    }
}
