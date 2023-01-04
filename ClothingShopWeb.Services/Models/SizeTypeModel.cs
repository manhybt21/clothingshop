using System;

namespace ClothingShopWeb.Data.Entities
{
    
    public class SizeTypeModel
    {
        public string SizeTypeCode { get; set; }
        public string SizeTypeName { get; set; }
        public string Description { get; set; }
        public virtual ProductSize ProductSizes { set; get; }
    }
}
