using System;

namespace ClothingShopWeb.Data.Entities
{
    
    public class CategoryModel
    {
        public string CategoryCode { set; get; }
        public string CategoryName { set; get; }
        public DateTime CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }
        public string Status { set; get; }
    }
}
