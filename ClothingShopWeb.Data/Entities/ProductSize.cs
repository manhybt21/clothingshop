using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("ProductSize")]
    public class ProductSize
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid SizeId { set; get; }
        public virtual Product Product { get; set; }    
        public virtual SizeType SizeTypes { get; set; }
    }
}
