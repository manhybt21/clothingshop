using System;

namespace ClothingShopWeb.Data.Entities
{
    public class ProductImageModel
    {
        public string ImageLink { set; get; }
        public byte[] Image { set; get; }
        public virtual Product Product { set; get; }

    }
}
