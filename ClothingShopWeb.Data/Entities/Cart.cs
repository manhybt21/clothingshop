using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public Guid Id { set; get; }
        public Guid ProductId { set; get; }
        public virtual Product Product { set; get; }
        public Guid TransactionId { set; get; }
        public virtual Transaction Transaction { set; get; }
        [Required]
        public int Amount{ set; get; }
        public string Status{ set; get; }
        public DateTime CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }

    }
}
