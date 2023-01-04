using ClothingShopWeb.Data.DBContext;
using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.Services
{
    public class ColorTypeServices : IColorTypeServices
    {
        private readonly DB_Context _context;
        public ColorTypeServices(DB_Context context)
        {
            _context = context;
        }
        public async Task<bool> CreateNewColor(ColorModel data)
        {
            bool result = false;
            try
            {
                ColorType color = new ColorType();
                if (data!=null)
                {
                    color.Id = Guid.NewGuid();
                    color.ColorCode = data.ColorCode;
                    color.ColorName = data.ColorName;
                    color.PastelColor = data.PastelColor;
                    color.Description = data.Description;
                    await _context.ColorTypes.AddAsync(color);
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

        public async Task<bool> DeleteColor(Guid id)
        {
            bool result = false;
            try
            {
                var color =await _context.ColorTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (color!=null)
                {
                    var lstProductColor =await _context.ProductColors.Where(x=>x.ColorTypeId == color.Id).ToListAsync();
                    if (lstProductColor!=null&&lstProductColor.Count>0)
                    {
                        _context.RemoveRange(lstProductColor);
                    }
                    _context.ColorTypes.Remove(color);
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

        public async Task<bool> UpdateColor(Guid id,ColorModel data)
        {
            bool result = false;
            try
            {
                var color =await _context.ColorTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (color != null)
                {
                    color.ColorCode = data.ColorCode;
                    color.ColorName = data.ColorName;
                    color.PastelColor = data.PastelColor;
                    color.Description = data.Description;
                    _context.ColorTypes.Update(color);
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

        public async Task<List<ColorType>> ViewListColor()
        {
            List<ColorType> result = new List<ColorType>();
            try
            {
                result = await _context.ColorTypes.ToListAsync();
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
    }
}
