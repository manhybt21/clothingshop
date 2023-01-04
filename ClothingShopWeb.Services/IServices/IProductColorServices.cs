using ClothingShopWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface IProductColorServices
    {
        public Task<bool> CreateProductColor(ProductColorModel data);
        public Task<bool> UpdateProductColor(Guid id,ProductColorModel data);
        public Task<bool> DeleteProductColor(Guid id);
        public Task<List<ProductColor>> ViewListProductColor();
    }
}
