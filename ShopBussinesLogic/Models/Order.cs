using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeShop.Models
{
    public class Order: IEquatable<Order>
    {
        public int Id { get; set; }
        public Dictionary<Product,int> OrderedProducts { get; set; }
        public string DeliveryAddress { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Order)
            {
                Order other = obj as Order;

                return Equals(other);
            }

            return false;
        }

        public bool Equals(Order other)
        {
            if (other.Id == Id)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return  Id.GetHashCode();
        }

    }
}
