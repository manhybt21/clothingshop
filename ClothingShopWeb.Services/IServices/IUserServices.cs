using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface IUserServices
    {
        public Task<bool> CreateAccount(UserModel data);
        public Task<bool> DeleteAccount(Guid id);
        public Task<bool> UpdateAccount(Guid id, UserModel data);
        public Task<User> FindAccountById(Guid id);
        public Task<User> FindAccountByUserName(string textSearch);
        public Task<bool> ForgotPassword(string email);
        public Task<bool> ChangePassword(Guid id, UserModel data);
        public Task<bool> Loggin(string userNameOrEmail,string password);
        public Task<List<User>> GetAllUsers();
    }
}
