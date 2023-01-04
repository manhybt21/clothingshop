using System;

namespace ClothingShopWeb.Data.Entities
{
    
    public class ProductColorModel
    {
        public Guid ColorTypeId { set; get; }
        public virtual ColorType ColorType { get; set; }
        public Guid ProductId { set; get; }
        public virtual Product Product { get; set; }
    }
}
