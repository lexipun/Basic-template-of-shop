
using DataAccess.ContextOfEntities;
using ShopBussinesLogic.Extensions;
using ShopBussinesLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityOrderedProduct = DataAccess.Entities.OrderedProduct;
using EntityOrder = DataAccess.Entities.Order;
using EntityProduct = DataAccess.Entities.Product;


namespace ShopBussinesLogic.ProductOperations
{
    public class BasicCRUD
    {
        private SomeShopContext context;

        public BasicCRUD()
        {
            context = new SomeShopContext();
        }
        public List<Product> GetAllProducts()
        {
            List<Product> result = ModelsConverter.ConvertEFProducts(context.Products.ToList());


            return result;
        }
        public void Create(Product product)
        {

            context.Add(ModelsConverter.ConvertBLProduct(product));
            context.SaveChanges();
        }

        public int CreateOrder()
        {
            EntityOrder entityOrder = new EntityOrder();
            context.Orders.Add(entityOrder);
            context.SaveChanges();

            return entityOrder.Id;
        }

        public Order GetOrderById(int id)
        {
            EntityOrder entityOrder = context.Orders.Find(id);
            Product product;
            EntityProduct entityProduct;
            Order order = new Order()
            {
                Id = entityOrder.Id,
                OrderedProducts = new Dictionary<Product, int>(),
            };

            List<EntityOrderedProduct> orderedProducts = context.OrderedProducts.Where(orderedProduct => orderedProduct.OrderId == id).ToList();

            foreach (var item in orderedProducts)
            {
                entityProduct = context.Products.Find(item.ProductId);
                product = ModelsConverter.ConvertEFProduct(entityProduct);

                if(product.Count < item.Count)
                {
                    product.State = ProductState.NotInStock;
                }

                order.OrderedProducts.Add(product, item.Count);
            }

            return order;
        }

        public void FillOrder(string email, string adress, int id)
        {
            EntityOrder entityOrder = context.Orders.Find(id);
            entityOrder.DeliveryAddress = adress;
            entityOrder.Email = email;
        }

        public EntityOrderedProduct CreateOrderProduct(int orderId, int productId)
        {
            EntityOrderedProduct orderedProduct = new()
            {
                OrderId = orderId,
                ProductId = productId,
            };

            context.OrderedProducts.Add(orderedProduct);
            context.SaveChanges();

            return orderedProduct;
        }

        public void SetProductOrder(int productId, int count, int OrderId)
        {
            EntityOrderedProduct orderedProduct = context.OrderedProducts.FirstOrDefault(orderedProduct => orderedProduct.ProductId == productId && orderedProduct.OrderId == OrderId);
            EntityProduct product = context.Products.Find(productId);

            if (orderedProduct is null)
            {
                orderedProduct = CreateOrderProduct(OrderId, productId);
            }

            orderedProduct.Count += count;
            context.SaveChanges();


        }
        private bool ClearOrderedProductsOfOrder(int orderId)
        {
            EntityOrderedProduct item;
            EntityProduct entityProduct;
            List<EntityOrderedProduct> orderedProducts = context.OrderedProducts.Where(orderedProduct => orderedProduct.OrderId == orderId).ToList();
            int index = 0;

            while (orderedProducts.Count > index)
            {
                item = orderedProducts[index];
                entityProduct = context.Products.Find(item.ProductId);

                if (entityProduct.Count > item.Count)
                {
                    entityProduct.Count -= item.Count;
                    context.OrderedProducts.Remove(item);
                    orderedProducts.RemoveAt(index);
                    continue;
                }

                ++index;
            }

                context.SaveChanges();

            if (orderedProducts.Count > 0)
            {
                return false;
            }

            return true;
        }
        public bool RemoveOrderById(int id)
        {
            
            EntityOrder entityOrder = context.Orders.Find(id);
           
            if(ClearOrderedProductsOfOrder(id))
            {
                context.Orders.Remove(entityOrder);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
