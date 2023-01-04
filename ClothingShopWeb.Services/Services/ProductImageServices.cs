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
    public class ProductImageServices : IProductImageServices
    {
        private readonly DB_Context _context;
        public ProductImageServices(DB_Context context)
        {
            _context = context;
        }
        public async Task<bool> CreateProductImage(ProductImageModel data)
        {
            bool result = false;
            try
            {
                ProductImage productImage = new ProductImage();
                if (data!=null)
                {
                    productImage.Id = Guid.NewGuid();
                    productImage.Image = data.Image;
                    productImage.ImageLink = data.ImageLink;
                    productImage.Product = data.Product;
                    await _context.ProductImages.AddAsync(productImage);
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

        public async Task<bool> DeleteProductImage(Guid id)
        {
            bool result = false;
            try
            {
                var productImage =await _context.ProductImages.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (productImage!=null)
                {
                    _context.ProductImages.Remove(productImage);
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

        public async Task<bool> UpdateProductImage(Guid id,ProductImageModel data)
        {
            bool result = false;
            try
            {
                var productImage =await _context.ProductImages.FirstOrDefaultAsync(x => x.Id == id);
                if (productImage != null)
                {
                    productImage.Image = data.Image;
                    productImage.ImageLink = data.ImageLink;
                    productImage.Product = data.Product;
                    _context.ProductImages.Update(productImage);
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

        public async Task<List<ProductImage>> ViewListProductImage()
        {
            List<ProductImage> result = new List<ProductImage>();
            try
            {
                result =await _context.ProductImages.ToListAsync();
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
    }
}
