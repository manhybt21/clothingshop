using ClothingShopWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface ICartServices
    {
        public Task<bool> CreateNewCart(CartModel data);
        public Task<bool> UpdateCart(Guid id,CartModel data);
        public Task<bool> DeleteCart(Guid id);
        public Task<List<Cart>> ViewListCart();
    }
}
