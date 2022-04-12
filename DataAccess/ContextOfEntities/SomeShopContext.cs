using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ContextOfEntities
{
    public class SomeShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SomeShop;Trusted_Connection=True;");
            }
        }
    }
}
