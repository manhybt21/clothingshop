using ClothingShopWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface IProductServices
    {
        public Task<bool> CreateProduct(ProductModel data);
        public Task<bool> UpdateProduct(Guid id,ProductModel data);
        public Task<bool> DeleteProduct(Guid id);
        public Task<List<Product>> ViewListProduct();
        public Task<Product> ViewProduct(Guid Id);
        public Task<List<Product>> FindProductByName(string productname);
    }
}
