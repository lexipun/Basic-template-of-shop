using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class OrderedProduct
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Count { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }

    }
}
