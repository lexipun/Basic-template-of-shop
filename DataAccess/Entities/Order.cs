using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<OrderedProduct> OrderedProducts { get; set; }
        public string DeliveryAddress { get; set; }
        public string Email { get; set; }
    }
}
