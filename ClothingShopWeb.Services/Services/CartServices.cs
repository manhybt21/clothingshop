using ClothingShopWeb.Data.DBContext;
using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.Services
{
    public class CartServices : ICartServices
    {
        private readonly DB_Context _context;
        public CartServices(DB_Context context)
        {
            _context = context;
        }
        public async Task<bool> CreateNewCart(CartModel data)
        {
            bool result = false;
            try
            {
                Cart cart = new Cart();
                if (data == null)
                {
                    cart.Id = Guid.NewGuid();
                    cart.Amount = data.Amount;
                    cart.Status = data.Status;
                    cart.CreateDate = data.CreateDate;
                    cart.UpdateDate = data.UpdateDate;
                    cart.CreateBy = data.CreateBy;
                    cart.UpdateBy = data.UpdateBy;
                    result = true;
                }
                if (result == true)
                {
                    await _context.Carts.AddAsync(cart);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteCart(Guid id)
        {
            bool result = false;
            try
            {
                var cart = await _context.Carts.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (cart!=null)
                {
                    _context.Carts.Remove(cart);
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

        public async Task<bool> UpdateCart(Guid id,CartModel data)
        {
            bool result = false;
            try
            {
                var cart =await _context.Carts.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (cart != null)
                {
                    cart.Amount = data.Amount;
                    cart.Status = data.Status;
                    cart.UpdateDate = data.UpdateDate;
                    cart.UpdateBy = data.UpdateBy;
                    result = true;
                }
                if (result == true)
                {
                    _context.Carts.Update(cart);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<List<Cart>> ViewListCart()
        {
            List<Cart> result = new List<Cart>();
            try
            {
                var lstCart = await _context.Carts.ToListAsync();
                if (lstCart!=null && lstCart.Count>0)
                {
                    result = lstCart;
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
