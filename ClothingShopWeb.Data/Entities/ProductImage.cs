using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("ProductImage")]
    public class ProductImage
    {
        [Key]
        public Guid Id { set; get; }
        public string ImageLink { set; get; }
        public  byte[] Image { set; get; }
        public Guid ProductId { get; set; }
        public virtual Product Product { set; get; }

    }
}
