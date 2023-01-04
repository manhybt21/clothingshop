using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface IRoleServices
    {
        public Task<bool> CreateNewRole(RoleModel item);
        public Task<bool> UpdateRole(Guid id,RoleModel data);
        public Task<Role> SearchRole(string text);
        public Task<bool> DeleteRole(Guid id);
        public Task<List<Role>> ViewListRole();
    }
}
