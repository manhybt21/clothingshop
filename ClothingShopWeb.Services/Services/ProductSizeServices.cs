using ClothingShopWeb.Data.DBContext;
using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.Services
{
    public class ProductSizeServices : IProductSizeServices
    {
        private readonly DB_Context _context;
        public ProductSizeServices(DB_Context context)
        {
            _context = context;
        }

        public async Task<bool> CreateProductSize(ProductSizeModel data)
        {
            bool result = false;
            try
            {
                ProductSize productSize = new ProductSize();
                if (data!=null)
                {
                    productSize.Id = Guid.NewGuid();
                    productSize.ProductId = data.ProductId;
                    productSize.SizeId = data.SizeId;
                    productSize.SizeTypes = data.SizeTypes;
                    productSize.Product = data.Product;
                    await _context.ProductSizes.AddAsync(productSize);
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

        public async Task<bool> DeleteProductSize(Guid id)
        {
            bool result = false;
            try
            {
                var productSize = await _context.ProductSizes.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (productSize!=null)
                {
                    _context.ProductSizes.Remove(productSize);
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

        public async Task<bool> UpdateProductSize(Guid id,ProductSizeModel data)
        {
            bool result = false;
            try
            {
                var productSize =await _context.ProductSizes.Where(x => x.Id== id).FirstOrDefaultAsync();
                if (productSize != null)
                {
                    productSize.ProductId = data.ProductId;
                    productSize.SizeId = data.SizeId;
                    productSize.SizeTypes = data.SizeTypes;
                    _context.ProductSizes.Update(productSize);
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

        public async Task<List<ProductSize>> ViewListProductSize()
        {
            List<ProductSize> result = new List<ProductSize>();
            try
            {
                result =await _context.ProductSizes.ToListAsync();
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
    }
}
