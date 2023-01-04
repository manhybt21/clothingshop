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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionServices _services;
        public TransactionController(ITransactionServices services)
        {
            _services = services;
        }
        // GET: api/<ProductColorController>
        [HttpGet("GetAllTransaction")]
        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await _services.ViewListTransaction();
        }
        // POST api/<ProductColorController>
        [HttpPost("CreateTransaction")]
        public async Task<bool> CreateTransaction([FromBody] TransactionModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
              result = await  _services.CreateTransaction(value);
            }
            return result;
        }

        // PUT api/<ProductColorController>/5
        [HttpPut("UpdateTransaction/{id}")]
        public async Task<bool> UpdateTransaction(Guid id, [FromBody] TransactionModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
               result = await _services.UpdateTransaction(id, value);
            }
            return result;
        }

        // DELETE api/<ProductColorController>/5
        [HttpDelete("DeleteTransaction/{id}")]
        public async Task<bool> DeleteProductColor(Guid id)
        {
            bool result = false;
            if (id != null)
            {
               result = await _services.DeleteTransaction(id);
            }
            return result;
        }
    }
}
