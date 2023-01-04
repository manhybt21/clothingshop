using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public Guid Id { set; get; }
        [Required]
        public string CategoryCode { set; get; }
        [Required]
        public string CategoryName { set; get; }
        public DateTime CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }
        public string Status { set; get; }
        public ICollection<Product> Products { set; get; }
    }
}
