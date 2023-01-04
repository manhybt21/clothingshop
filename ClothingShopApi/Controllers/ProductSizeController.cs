using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothingShopWeb.Data.DBContext;
using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;

namespace ClothingShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : ControllerBase
    {
        private readonly IProductSizeServices _productSizeServices;

        public ProductSizeController(IProductSizeServices productSizeServices)
        {
            _productSizeServices = productSizeServices;
        }

        // GET: api/ProductSize
        [HttpGet("GetAllProductSizes")]
        public async Task<IActionResult> GetProductSizes()
        {
            var result = await _productSizeServices.ViewListProductSize();
            return Ok(result);
        }

       

        // PUT: api/ProductSize/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("UpdateProductSize/{id}")]
        public async Task<IActionResult> UpdateProductSize(Guid id, ProductSizeModel productSize)
        {
            try
            {
                await _productSizeServices.UpdateProductSize(id,productSize);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id!=null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductSize
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("CreateProductSize")]
        public async Task<ActionResult<ProductSize>> CreateProductSize(ProductSizeModel productSize)
        {
            if (ModelState.IsValid)
            {
                await _productSizeServices.CreateProductSize(productSize);
            }

            return CreatedAtAction("GetProductSize", productSize);
        }

        // DELETE: api/ProductSize/5
        [HttpDelete("DeleteProductSize/{id}")]
        public async Task<IActionResult> DeleteProductSize(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _productSizeServices.DeleteProductSize(id);

            return Ok();
        }

    }
}
