using ClothingShopWeb.Services.IServices;
using ClothingShopWeb.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ClothingShopWeb.Data.DBContext;
using ClothingShopWeb.Data.Entities;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;

namespace ClothingShopWeb.Services.Services
{
    public class RoleServices : IRoleServices
    {
        public readonly DB_Context _Context;
        public readonly IUserServices _userServices;
        public RoleServices(DB_Context context, IUserServices userServices)
        {
            _Context = context;
            _userServices = userServices;
        }
        public RoleServices()
        {

        }
        public async Task<bool> CreateNewRole(RoleModel item)
        {
            bool result = false;
            Role role = new Role();
            try
            {
                if (item != null)
                {
                    role.Id = Guid.NewGuid();
                    role.RoleCode = item.RoleCode;
                    role.RoleName = item.RoleName;
                    role.Status = item.Status;
                    await _Context.Roles.AddAsync(role);
                    _Context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteRole(Guid id)
        {
            bool result = false;
            try
            {
                var findRoleById =await _Context.Roles.Where(x=>x.Id==id).FirstOrDefaultAsync();
                if (findRoleById != null)
                {
                    // delete user
                    var lstUser =await _Context.Users.Where(x=>x.RoleId==findRoleById.Id).Select(x=>x.Id).ToListAsync();
                    if (lstUser!=null&&lstUser.Count>0)
                    {
                        foreach (var item in lstUser)
                        {
                            await _userServices.DeleteAccount(item);
                        }
                    }
                    _Context.Roles.Remove(findRoleById);
                    await _Context.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<Role> SearchRole(string text)
        {
            Role result = new Role();
            try
            {
                if (text != null && text != string.Empty)
                {
                    var role = await _Context.Roles.Where(x => x.RoleName.Contains(text)).FirstOrDefaultAsync();
                    if (role != null)
                    {
                        result = role;
                    }
                }
            }
            catch (Exception)
            {
                result = null;
                throw;
            }
            return result;
        }

        public async Task<bool> UpdateRole(Guid id,RoleModel data)
        {
            bool result = false;
            try
            {
                var findRole =await _Context.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (findRole!=null)
                {
                    findRole.RoleCode = data.RoleCode;
                    findRole.RoleName = data.RoleName;
                    findRole.Status = data.Status;
                    _Context.Roles.Update(findRole);
                    _Context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<List<Role>> ViewListRole()
        {
            List<Role> result = new List<Role>();
            try
            {
                var lstRole =await _Context.Roles.ToListAsync();
                if (lstRole!=null || lstRole.Count>0)
                {
                    result = lstRole;
                }
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
    }
}
