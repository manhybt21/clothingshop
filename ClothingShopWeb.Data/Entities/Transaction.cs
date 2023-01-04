using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public Guid Id { set; get; }
        public string UserId { get; set; }
        public virtual User Users { set; get; }
        public string Message { set; get; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }
    }
}
