using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingShopWeb.Data.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public Guid Id { set; get; }
        public string RoleCode { get; set; }
        public string RoleName { set; get; }
        public int? Status { get; set; }
        public ICollection<User> IC_Users { set; get; }
    }
}
