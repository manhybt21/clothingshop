using ClothingShopWeb.Data.DBContext;
using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.Services
{
    public class SizeTypeServices : ISizeTypeServices
    {
        private readonly DB_Context _context;
        public SizeTypeServices(DB_Context context)
        {
            _context = context;
        }

        public async Task<bool> AddNewSize(SizeTypeModel data)
        {
            bool result = false;
            try
            {
                if (data!=null)
                {
                    SizeType sizeType = new SizeType();
                    sizeType.Id = Guid.NewGuid();
                    sizeType.SizeTypeCode = data.SizeTypeCode;
                    sizeType.SizeTypeName = data.SizeTypeName;
                    sizeType.Description = data.Description;
                    await _context.SizeTypes.AddAsync(sizeType);
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

        public async Task<bool> DeleteSize(Guid id)
        {
            bool result = false;
            try
            {
                var sizeType =await _context.SizeTypes.Where(x=>x.Id==id).FirstOrDefaultAsync();
                if (sizeType!=null)
                {
                    var lstProductSize = await _context.ProductSizes.Where(x=>x.SizeId==sizeType.Id).ToListAsync();
                    if (lstProductSize!=null&&lstProductSize.Count>0)
                    {
                        _context.ProductSizes.RemoveRange(lstProductSize);
                    }
                    _context.SizeTypes.Remove(sizeType);
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

        public async Task<bool> UpdateSize(Guid id,SizeTypeModel data)
        {
            bool result = false;
            try
            {
                var sizeType =await _context.SizeTypes.Where(x => x.Id ==id).FirstOrDefaultAsync();
                if (sizeType != null)
                {
                    sizeType.SizeTypeCode = data.SizeTypeCode;
                    sizeType.SizeTypeName = data.SizeTypeName;
                    sizeType.Description = data.Description;
                    _context.SizeTypes.Update(sizeType);
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

        public async Task<List<SizeType>> ViewListSize()
        {
            List<SizeType> result = new List<SizeType>();
            try
            {
                result =await _context.SizeTypes.ToListAsync();
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
    }
}
