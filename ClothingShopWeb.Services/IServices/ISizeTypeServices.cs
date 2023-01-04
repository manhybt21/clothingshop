using ClothingShopWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface ISizeTypeServices
    {
        public Task<bool> AddNewSize(SizeTypeModel data);
        public Task<bool> UpdateSize(Guid id,SizeTypeModel data);
        public Task<bool> DeleteSize(Guid id);
        public Task<List<SizeType>> ViewListSize();
    }
}
