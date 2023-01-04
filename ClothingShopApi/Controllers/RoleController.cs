using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using ClothingShopWeb.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClothingShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _services;
        public RoleController(IRoleServices services)
        {
            _services = services;
        }
    
        // GET: api/<RoleController>
        [HttpGet("GetAllRoles")]
        public Task<List<Role>> Get()
        {
            return _services.ViewListRole();
        }

        // GET api/<RoleController>/5
        [HttpGet("FindByRoleName/{rolename}")]
        public Task<Role> Get(string roleName)
        {
            return _services.SearchRole(roleName);
        }

        // POST api/<RoleController>
        [HttpPost("CreateRole")]
        public async Task<bool> CreateRole([FromBody] RoleModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
               result = await _services.CreateNewRole(value);
            }
            return result;
        }

        // PUT api/<RoleController>/5
        [HttpPut("UpdateRole/{id}")]
        public async Task<bool> UpdateRole(Guid id, [FromBody] RoleModel value)
        {
            bool result = false;
            if (id!=null && ModelState.IsValid)
            {
               result = await _services.UpdateRole(id,value);
            }
            return result;
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("DeleteRole/{id}")]
        public async Task<bool> DeleteRole(Guid id)
        {
            bool result = false;
            if (id!=null)
            {
              result = await  _services.DeleteRole(id);
            }
            return result;
        }
    }
}
