using ClothingShopWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClothingShopWeb.Data.DBContext
{
    public class DB_Context: DbContext
    {
        public DB_Context()
        {

        }
        public DB_Context(DbContextOptions<DbContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("CloingShop");

            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<User> Users { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { set; get; }
        public DbSet<ProductImage> ProductImages { set; get; }
        public DbSet<ColorType> ColorTypes { set; get; }
        public DbSet<ProductColor> ProductColors { set; get; }
        public DbSet<SizeType> SizeTypes { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<Transaction> Transactions { set; get; }
    }
}
