using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("SizeTypes")]
    public class SizeType
    {
        [Key]
        public Guid Id { set; get; }
        public string SizeTypeCode { get; set; }
        public string SizeTypeName { get; set; }
        public string Description { get; set; }
        public  ICollection<ProductSize> ProductSizes { set; get; }
    }
}
