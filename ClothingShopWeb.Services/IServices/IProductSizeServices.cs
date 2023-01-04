using ClothingShopWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface IProductSizeServices
    {
        public Task<bool> CreateProductSize(ProductSizeModel data);
        public Task<bool> UpdateProductSize(Guid id,ProductSizeModel data);
        public Task<bool> DeleteProductSize(Guid id);
        public Task<List<ProductSize>> ViewListProductSize();
    }
}
