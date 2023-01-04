using System;

namespace ClothingShopWeb.Data.Entities
{
    public class CartModel
    {
        public int Amount{ set; get; }
        public string Status{ set; get; }
        public DateTime CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }

    }
}
