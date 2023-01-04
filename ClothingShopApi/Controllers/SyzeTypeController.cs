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
    public class SyzeTypeController : ControllerBase
    {
        private readonly ISizeTypeServices _sizeTypeServices;
        public SyzeTypeController(ISizeTypeServices sizeTypeServices)
        {
            _sizeTypeServices = sizeTypeServices;
        }

        // GET: api/<SyzeTypeController>
        [HttpGet("GetAllsSize")]
        public Task<List<SizeType>> GetAlls()
        {
            return _sizeTypeServices.ViewListSize();
        }
        // POST api/<SyzeTypeController>
        [HttpPost("CreateSize")]
        public async Task<bool> CreateSizeType([FromBody] SizeTypeModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
               result = await _sizeTypeServices.AddNewSize(value);
            }
            return result;
        }

        // PUT api/<SyzeTypeController>/5
        [HttpPut("UpdateSize/{id}")]
        public async Task<bool> UpdateSizeType(Guid id, [FromBody] SizeTypeModel value)
        {
            bool result = false;
            if (ModelState.IsValid&& id!=null)
            {
               result = await _sizeTypeServices.UpdateSize(id, value);
            }
            return result;
        }

        // DELETE api/<SyzeTypeController>/5
        [HttpDelete("DeleteSize/{id}")]
        public async Task<bool> DeleteSize(Guid id)
        {
            bool result = false;
            if (id!=null)
            {
              result = await  _sizeTypeServices.DeleteSize(id);
            }
            return result;
        }
    }
}
