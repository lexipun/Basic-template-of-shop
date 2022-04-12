using AutoMapper;
using DataAccessLayer.ContextOfEntities;
using ShopBussinesLogic.Extensions;
using ShopBussinesLogic.Models;
using SomeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
