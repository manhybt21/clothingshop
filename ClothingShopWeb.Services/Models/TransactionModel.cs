using System;
namespace ClothingShopWeb.Data.Entities
{
    public class TransactionModel
    {
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
