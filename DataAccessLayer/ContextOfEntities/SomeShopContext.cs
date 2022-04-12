using DataAccessLayer.Entities;
using LinqToDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ContextOfEntities
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
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Trusted_Connection=True;");
            }
        }
    }
}
