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
   
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services; 
        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }
        // GET: api/<CategoryController>
        [HttpGet("/GetAllCategories")]
        public Task<List<Category>> GetAlls()
        {
            return _services.ViewListCategory();
        }
        // POST api/<CategoryController>
        [HttpPost("/CreateCategory")]
        public async Task<bool> CreateCategory([FromBody] CategoryModel data)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result =await _services.CreateCategory(data);
            }
            return result;
        }

        // PUT api/<CategoryController>/5
        [HttpPost("/UpdateCategory/{id}")]
        public async Task<bool> UpdateCategory(Guid id, [FromBody] CategoryModel data)
        {
            bool result = false;
            if (id!=null && ModelState.IsValid)
            {
               result = await _services.UpdateCategory(id, data);
            }
            return result;
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("/DeleteCategory/{id}")]
        public async Task<bool> DeleteCategory(Guid id)
        {
            bool result = false;
            if (id!=null)
            {
               result = await _services.DeleteCategory(id);
            }
            return result;
        }
    }
}
