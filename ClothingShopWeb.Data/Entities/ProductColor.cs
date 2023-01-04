using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("ProductColor")]
    public class ProductColor
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ColorTypeId { set; get; }
        public virtual ColorType ColorType { get; set; }
        public Guid ProductId { set; get; }
        public virtual Product Product { get; set; }
    }
}
