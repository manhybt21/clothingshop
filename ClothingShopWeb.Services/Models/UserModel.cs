using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingShopWeb.Services.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public byte[] Avatar { set; get; }
        public string Password { get; set; }
        public string Email { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { set; get; }
        public Guid RoleId { get; set; }
        public virtual RoleModel Roles { set; get; }
        public string Status { get; set; }
        public DateTime CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }
    }
}
