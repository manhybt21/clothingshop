using ClothingShopWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface IColorTypeServices
    {
        public Task<bool> CreateNewColor(ColorModel data);
        public Task<bool> DeleteColor(Guid id);
        public Task<bool> UpdateColor(Guid id,ColorModel data);
        public Task<List<ColorType>> ViewListColor();
    }
}
