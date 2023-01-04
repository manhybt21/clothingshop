using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public byte[] Avatar { set; get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { set; get; }
        public Guid RoleId { get; set; }
        public virtual Role Roles { set; get; }
        public string Status { get; set; }
        public DateTime CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }

    }
}
