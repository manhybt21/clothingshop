using System;

namespace ClothingShopWeb.Data.Entities
{
   
    public class ProductModel
    {
        public string ProductCode { set; get; }
        public string ProductName{ set; get; }
        public decimal Price{ set; get; }
        public string Description{ set; get; }
        public decimal PromotionPrice{ set; get; }
        public decimal VAT{ set; get; }
        public string Quantity{ set; get; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { set; get; }
        public string Detail{ set; get; }
        public int Counts{ set; get; }
        public DateTime CreateDate{ set; get; }
        public string CreateBy{ set; get; }
        public DateTime? UpdateDate{ set; get; }
        public string UpdateBy{ set; get; }
        public string Status{ set; get; }
        public decimal Discount{ set; get; }
        public Guid ImagesId{ set; get; }
        public string Sex { get; set; }
        public byte[] Image { set; get; }
    }
}
