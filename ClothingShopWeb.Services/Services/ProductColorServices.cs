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
    public class ProductColorServices : IProductColorServices
    {
        private readonly DB_Context _context;
        public ProductColorServices(DB_Context context)
        {
            _context = context;
        }
        public async Task<bool> CreateProductColor(ProductColorModel data)
        {
            bool result = false;
            try
            {
                ProductColor productColor = new ProductColor();
                if (data!=null)
                {
                    productColor.Id = Guid.NewGuid();
                    productColor.ProductId = data.ProductId;
                    productColor.Product = data.Product;
                    productColor.ColorTypeId = data.ColorTypeId;
                    productColor.ColorType = data.ColorType;
                    await _context.ProductColors.AddAsync(productColor);
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

        public async Task<bool> DeleteProductColor(Guid id)
        {
            bool result = false;
            try
            {
                var productColor =await  _context.ProductColors.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (productColor!= null)
                {
                    _context.ProductColors.Remove(productColor);
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

        public async Task<bool> UpdateProductColor(Guid id,ProductColorModel data)
        {
            bool result = false;
            try
            {
                var productColor =await _context.ProductColors.Where(x => x.Id== id).FirstOrDefaultAsync();
                if (productColor != null)
                {
                    productColor.ProductId = data.ProductId;
                    productColor.Product = data.Product;
                    productColor.ColorTypeId = data.ColorTypeId;
                    productColor.ColorType = data.ColorType;
                    _context.ProductColors.Update(productColor);
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

        public async Task<List<ProductColor>> ViewListProductColor()
        {
            List<ProductColor> result = new List<ProductColor>();
            try
            {
                var lstProductColor = await _context.ProductColors.ToListAsync();
                if (lstProductColor != null&& lstProductColor.Count>0)
                {
                   
                    result = lstProductColor;
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
