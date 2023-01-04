using ClothingShopWeb.Data.DBContext;
using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly DB_Context _context;
        private readonly IProductServices _productServices;
        public CategoryServices(DB_Context context, IProductServices productServices)
        {
            _context = context;
            _productServices = productServices;
        }
        public async Task<bool> CreateCategory(CategoryModel data)
        {
            var result = false;
            try
            {
                if (data!=null)
                {
                    Category category = new Category();
                    category.Id = Guid.NewGuid();
                    category.CategoryName = data.CategoryName;
                    category.CategoryCode = data.CategoryCode;
                    category.UpdateDate = DateTime.Now;
                    category.CreateDate = DateTime.Now;
                    category.CreateBy = data.CreateBy;
                    category.UpdateBy = data.UpdateBy;
                    await _context.AddAsync(category);
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

        public async Task<bool> DeleteCategory(Guid id)
        {
            var result = false;
            try
            {
                var category =await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (category != null)
                {
                    // delete product
                    var lstProductId = _context.Products.Where(x => x.CategoryId == category.Id).Select(x=>x.Id).ToList();
                    if (lstProductId!=null&&lstProductId.Count>0)
                    {
                        foreach (var item in lstProductId)
                        {
                           await _productServices.DeleteProduct(item);
                        }
                    }
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return result;
        }

        public async Task<bool> UpdateCategory(Guid id,CategoryModel data)
        {
            var result = false;
            try
            {
                var category =await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (category != null)
                {
                    category.CategoryName = data.CategoryName;
                    category.CategoryCode = data.CategoryCode;
                    category.UpdateDate = DateTime.Now;
                    category.UpdateBy = data.UpdateBy;
                    _context.Categories.Update(category);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return result;
        }

        public async Task<List<Category>> ViewListCategory()
        {
            List<Category> result = new List<Category>();
            try
            {
                result = await _context.Categories.ToListAsync();
            }
            catch (Exception)
            {
                result = null;
                throw;
            }
            return result;
        }
    }
}
