using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("ColorType")]
    public class ColorType
    {
        [Key]
        public Guid Id { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string PastelColor { get; set; }
        public string Description { get; set; }
        public ICollection<ProductColor> ProductColors { set; get; }
    }
}
