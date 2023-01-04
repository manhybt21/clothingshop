using ClothingShopWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface ICategoryServices
    {
        public Task<bool> CreateCategory(CategoryModel data);
        public Task<bool> UpdateCategory(Guid id,CategoryModel data);
        public Task<bool> DeleteCategory(Guid id);
        public Task<List<Category>> ViewListCategory();

    }
}
