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
    public class ColorTypeController : ControllerBase
    {
        private readonly IColorTypeServices _colorTypeServices;
        public ColorTypeController(IColorTypeServices colorTypeServices)
        {
            _colorTypeServices = colorTypeServices;
        }
        // GET: api/<ColorTypeController>
        [HttpGet("GetAllColors")]
        public Task<List<ColorType>> GetAllColors()
        {
            return _colorTypeServices.ViewListColor();
        }

        // POST api/<ColorTypeController>
        [HttpPost("CreateNewColor")]
        public async Task<bool> CreateNewColor([FromBody] ColorModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = await _colorTypeServices.CreateNewColor(value);
            }
            return result;
        }

        // PUT api/<ColorTypeController>/5
        [HttpPut("UpdateColor/{id}")]
        public async Task<bool> UpdateColor(Guid id, [FromBody] ColorModel value)
        {
            bool result = false;
            if (id!=null&&ModelState.IsValid)
            {
               result =await _colorTypeServices.UpdateColor(id,value);
            }
            return result;
        }

        // DELETE api/<ColorTypeController>/5
        [HttpDelete("DeleteColor/{id}")]
        public async Task<bool> Delete(Guid id)
        {
            bool result = false;
            if (id!=null)
            {
               result = await _colorTypeServices.DeleteColor(id);
            }
            return result;
        }
    }
}
