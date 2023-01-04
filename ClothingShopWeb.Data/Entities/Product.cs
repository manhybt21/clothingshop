using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid Id { set; get; }
        [Required]
        public string ProductCode { set; get; }
        [Required]
        public string ProductName{ set; get; }
        [Required]
        public decimal Price{ set; get; }
        public string Description{ set; get; }
        [Required]
        public decimal PromotionPrice{ set; get; }
        public decimal VAT{ set; get; }
        public string Quantity{ set; get; }
        public Guid CategoryId { set; get; }
        public virtual Category Category { set; get; }
        public string Detail{ set; get; }
        [Required]
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
        public ICollection<ProductImage> IC_ProductImages { set; get; }
        public ICollection<Cart> IC_Carts { set; get; }
        public ICollection<ProductSize> IC_ProductSizes { set; get; }
        public ICollection<ProductColor> IC_ProductColor { set; get; }
    }
}
