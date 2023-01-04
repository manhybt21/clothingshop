using System;

namespace ClothingShopWeb.Data.Entities
{
    
    public class ProductSizeModel
    {
        public Guid ProductId { get; set; }
        public Guid SizeId { set; get; }
        public virtual SizeType SizeTypes { get; set; }
        public virtual Product Product { get; set; }
    }
}
