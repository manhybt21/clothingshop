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
    public class UserController : ControllerBase
    {
        public readonly IUserServices _services;
        public UserController(IUserServices services)
        {
            _services = services;
        }
        // GET: api/<UserController>
        [HttpGet("GetAllUsers")]
        public Task<List<User>> GetAllsUsers()
        {
            return _services.GetAllUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("GetUser/{id}")]
        public Task<User> FindById(Guid id)
        {
            if (id!=null)
            {
                return _services.FindAccountById(id);
            }
            else
            {
                return null;
            }
        }
        [HttpGet("GetUserByUserName/{username}")]
        public Task<User> FindUserByUserName(string username)
        {
            if (username != null)
            {
               return _services.FindAccountByUserName(username);
            }
            else
            {
                return null;
            }
        }

        // POST api/<UserController>
        [HttpPost("CreateUser")]
        public async Task<bool> CreateUser([FromBody] UserModel value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
               result = await _services.CreateAccount(value);
            }
            return result;
        }

        // PUT api/<UserController>/5
        [HttpPut("UpdateUser/{id}")]
        public async Task<bool> UpdateAccount(Guid id, [FromBody] UserModel value)
        {
            bool result = false;
            if (id!=null && ModelState.IsValid)
            {
               result = await _services.UpdateAccount(id,value);
            }
            return result;
        }
        [HttpPut("ChangedPassword/{id}")]
        public async Task<bool> ChangedPassword(Guid id, [FromBody] UserModel value)
        {
            bool result = false;
            if (id != null && ModelState.IsValid)
            {
                result = await _services.ChangePassword(id, value);
            }
            return result;
        }
        [HttpPut("ForgotPassword/{email}")]
        public async Task<bool> ForgotPassword(string email)
        {
            bool result = false;
            if (email != null )
            {
               result = await _services.ForgotPassword(email);
            }
            return result;
        }
        // DELETE api/<UserController>/5
        [HttpDelete("DeleteUser/{id}")]
        public async Task<bool> Delete(Guid id)
        {
            bool result = false;
            if (id!=null)
            {
               result = await _services.DeleteAccount(id);
            }
            return result;
        }
        [HttpGet("Loggin/{emailOrUserName}/{password}")]
        public async Task<bool> Loggin(string emailOrUserName,string password)
        {
            bool result = false;
            if (string.IsNullOrEmpty(emailOrUserName)||string.IsNullOrEmpty(password))
            {
                result = false;
            }
            result =await _services.Loggin(emailOrUserName, password);
            return result;
        }
    }
}
