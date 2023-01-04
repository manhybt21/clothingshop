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
    public class CartController : ControllerBase
    {
        private readonly ICartServices _services;
        public CartController(ICartServices services)
        {
            _services = services;
        }
        // GET: api/<ProductColorController>
        [HttpGet("/GetAllCart")]
        public async Task<List<Cart>> GetAllCarts()
        {
            return await _services.ViewListCart();
        }
        // POST api/<ProductColorController>
        [HttpPost("/CreateCart")]
        public async Task<bool> CreateCart([FromBody] CartModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
              result = await _services.CreateNewCart(value);
            }
            return result;
        }

        // PUT api/<ProductColorController>/5
        [HttpPut("/UpdateCart/{id}")]
        public async Task<bool> UpdateCart(Guid id, [FromBody] CartModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
               result =await _services.UpdateCart(id, value);
            }
             return result;
        }

        // DELETE api/<ProductColorController>/5
        [HttpDelete("/DeleteCart/{id}")]
        public async Task<bool> DeleteProductColor(Guid id)
        {
            bool result = false;
            if (id != null)
            {
              result = await  _services.DeleteCart(id);
            }
            return result;
        }
    }
}
