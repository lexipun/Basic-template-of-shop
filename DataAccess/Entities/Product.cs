using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataAccess.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateTime LastChange { get; set; }

    }
}
