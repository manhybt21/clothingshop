using ClothingShopWeb.Data.DBContext;
using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using ClothingShopWeb.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClothingShopWeb.Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly DB_Context _context;
        public UserServices(DB_Context context)
        {
            _context = context;
        }
        public UserServices()
        {

        }
        public async Task<bool> CreateAccount(UserModel data)
        {
            bool result = false;
            try
            {
                User user = new User();
                
                if (data!=null&& !data.Password.Contains(" "))
                {
                    string encryptedPassword = EncryptPasswordMD5(data.Password);//mã hóa mật khẩu theo md5
                    user.Id = Guid.NewGuid();
                    user.Password = encryptedPassword;
                    user.UserName = data.UserName;
                    user.Email = data.Email;
                    user.Avatar = data.Avatar;
                    user.FullName = data.FullName;
                    user.FirstName = data.FirstName;
                    user.LastName = data.LastName;
                    user.PhoneNumber = data.PhoneNumber;
                    user.Address = data.Address;
                    user.Status = data.Status;
                    user.RoleId = data.RoleId;
                    user.CreateBy = data.CreateBy;
                    user.CreateDate =DateTime.Now;
                    user.UpdateBy = data.UpdateBy;
                    user.UpdateDate = DateTime.Now;
                    result = true;
                }
                if (result == true)
                {
                   await _context.Users.AddAsync(user);
                   _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteAccount(Guid id)
        {
            bool result = false;
            try
            {
                var user =await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (user!=null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<User> FindAccountById(Guid id)
        {
            User result = new User();
            try
            {
                var account = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (account!=null)
                {
                    result = account;
                }
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }

        public async Task<User> FindAccountByUserName(string username)
        {
            User result = new User();
            try
            {
                var account = await _context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
                if (account != null)
                {
                    result = account;
                }
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }

        public async Task<bool> ForgotPassword(string email)
        {
            bool result = false;
            try
            {
                var account =await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
                if (account != null)
                {
                    string encryptedPassword = EncryptPasswordMD5("123456");//mã hóa mật khẩu theo md5
                    account.Password = encryptedPassword;
                    _context.Users.Update(account);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> UpdateAccount(Guid id,UserModel data)
        {
            bool result = false;
            try
            {
                var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    if (data.Password.Contains(" "))
                    {
                        result = false;
                    }
                    else
                    {
                        string encryptedPassword = EncryptPasswordMD5(data.Password);//mã hóa mật khẩu theo md5
                        var account = _context.Users.Where(x => x.Id == id).FirstOrDefault();
                        account.Password = encryptedPassword;
                        account.Avatar = data.Avatar;
                        account.FullName = data.FullName;
                        account.FirstName = data.FirstName;
                        account.LastName = data.LastName;
                        account.PhoneNumber = data.PhoneNumber;
                        account.Address = data.Address;
                        account.Status = data.Status;
                        account.RoleId = data.RoleId;
                        account.UpdateBy = data.UpdateBy;
                        account.UpdateDate = DateTime.Now;
                        result = true;
                        if (result == true)
                        {
                            _context.Users.Update(account);
                            _context.SaveChanges();
                        }
                    }
                    
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> lstUsers = new List<User>();
            try
            {
                lstUsers = await _context.Users.Include(x=>x.Roles).ToListAsync();
            }
            catch (Exception)
            {
                lstUsers = null;
            }
            return lstUsers;
        }

        public async Task<bool> Loggin(string userNameOrEmail, string password)
        {
            bool result = false;
            try
            {
                string encryptedPassword = EncryptPasswordMD5(password);
                var account =await _context.Users.Where(x => (x.UserName == userNameOrEmail || x.Email == userNameOrEmail) && x.Password == encryptedPassword).FirstOrDefaultAsync();
                if (account!=null)
                {
                    result=true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public async Task<bool> ChangePassword(Guid id,UserModel data)
        {
            bool result = false;
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x=>x.Id==id);
                if (user!=null)
                {
                    user.Password = EncryptPasswordMD5(data.Password);
                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public string EncryptPasswordMD5(string password)
        {
            string encryptedPasswordMD5 = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(password);
            MD5 mD5 = MD5.Create();
            mD5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                encryptedPasswordMD5 += b.ToString("X2");
            }
            return encryptedPasswordMD5;
        }
    }
}
