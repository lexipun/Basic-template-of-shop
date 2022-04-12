using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBussinesLogic.Models
{
    public enum ProductState
    {
        Created,
        Processed,
        NotInStock,
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public ProductState State { get; set; }
    }
}
