using ClothingShopWeb.Data.DBContext;
using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.Services
{
    public class ProductServices : IProductServices
    {
        private readonly DB_Context _context;
        public ProductServices(DB_Context context)
        {
            _context =  context;
        }
        public async Task<bool> CreateProduct(ProductModel data)
        {
            bool result = false;
            try
            {
                Product product = new Product();
                if (data!=null)
                {
                    product.Id = Guid.NewGuid();
                    product.ProductCode = data.ProductCode;
                    product.ProductName = data.ProductName;
                    product.Description = data.Description;
                    product.Price = data.Price;
                    product.PromotionPrice = data.PromotionPrice;
                    product.Counts = data.Counts;
                    product.Quantity = data.Quantity;
                    product.Status = data.Status;
                    product.Category = data.Category;
                    product.Description = data.Description;
                    product.Sex = data.Sex;
                    product.VAT = data.VAT;
                    product.UpdateDate = data.UpdateDate;
                    product.UpdateBy = data.UpdateBy;
                    product.CreateBy = data.CreateBy;
                    product.CreateDate = data.CreateDate;
                    await _context.Products.AddAsync(product);
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
        public async Task<List<Product>> FindProductByName(string productName)
        {
            List<Product> result = new List<Product>();
            try
            {
                result =await _context.Products.Where(x => x.ProductName.Contains(productName)).ToListAsync();
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }

        public async Task<Product> ViewProduct(Guid Id)
        {
            Product result = new Product();
            try
            {
                result = await _context.Products.Where(x => x.Id==Id).Include(x=>x.Category).FirstOrDefaultAsync();
                result.IC_ProductColor = _context.ProductColors.Where(x => x.ProductId == result.Id).ToList();
                result.IC_ProductImages = _context.ProductImages.Where(x => x.ProductId == result.Id).ToList();
                result.IC_ProductSizes = _context.ProductSizes.Where(x => x.ProductId == result.Id).ToList();
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
        public async Task<bool> DeleteProduct(Guid id)
        {
            bool result = false;
            try
            {
                var product = _context.Products.Where(x=>x.Id==id).FirstOrDefault();
                if (product!=null)
                {
                    //delete product images
                    var lstProductImage =await _context.ProductImages.Where(x => x.ProductId == product.Id).ToListAsync();
                    if (lstProductImage!=null && lstProductImage.Count>0)
                    {
                        _context.ProductImages.RemoveRange(lstProductImage);
                    }
                    //delete product size
                    var lstProductSize =await _context.ProductImages.Where(x => x.ProductId == product.Id).ToListAsync();
                    if (lstProductImage != null && lstProductImage.Count > 0)
                    {
                        _context.ProductImages.RemoveRange(lstProductImage);
                    }
                    //delete product color
                    var lstProductColor = await _context.ProductColors.Where(x=>x.ProductId==product.Id).ToListAsync();
                    if (lstProductColor!=null &&lstProductColor.Count>0)
                    {
                        _context.ProductColors.RemoveRange(lstProductColor);
                    }
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> UpdateProduct(Guid id,ProductModel data)
        {
            bool result = false;
            try
            {
                var product =await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (product != null)
                {
                    product.ProductCode = data.ProductCode;
                    product.ProductName = data.ProductName;
                    product.Description = data.Description;
                    product.Price = data.Price;
                    product.PromotionPrice = data.PromotionPrice;
                    product.Counts = data.Counts;
                    product.Quantity = data.Quantity;
                    product.Status = data.Status;
                    product.CategoryId = data.CategoryId;
                    product.Description = data.Description;
                    product.Sex = data.Sex;
                    product.VAT = data.VAT;
                    product.UpdateDate = data.UpdateDate;
                    product.UpdateBy = data.UpdateBy;
                    product.CreateBy = data.CreateBy;
                    product.CreateDate = data.CreateDate;
                    _context.Products.Update(product);
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

        public async Task<List<Product>> ViewListProduct()
        {
            List<Product> result = new List<Product>();
            try
            {
                result =await _context.Products.Include(x=>x.Category).Include(x=>x.IC_ProductColor).Include(x=>x.IC_ProductImages).Include(x=>x.IC_ProductSizes).ToListAsync();
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
            
        }
    }
}
