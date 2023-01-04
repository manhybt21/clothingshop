using ClothingShopWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface IProductImageServices
    {
        public Task<bool> CreateProductImage(ProductImageModel data);
        public Task<bool> UpdateProductImage(Guid id,ProductImageModel data);
        public Task<bool> DeleteProductImage(Guid id);
        public Task<List<ProductImage>> ViewListProductImage();
    }
}
