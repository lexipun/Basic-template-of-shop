using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLProduct = ShopBussinesLogic.Models.Product;
using EFProduct = DataAccessLayer.Entities.Product;


namespace ShopBussinesLogic.Extensions
{
    class ModelsConverter
    {

        public static EFProduct ConvertBLProduct(BLProduct product)
        {

            EFProduct result = new()
            {
                Id = product.Id,
                Count = product.Count,
                Name = product.Name,
                Price = product.Price,
            };

            return result;
        }

        public static List<EFProduct> ConvertBLProducts(List<BLProduct> products)
        {
            List<EFProduct> result = new();


            foreach(BLProduct product in products)
            {
                result.Add(new EFProduct()
                {
                    Id = product.Id,
                    Count = product.Count,
                    Name = product.Name,
                    Price = product.Price,
                });
            }


            return result;
        }
        public static BLProduct ConvertEFProduct(EFProduct product)
        {

            BLProduct result = new()
            {
                Id = product.Id,
                Count = product.Count,
                Name = product.Name,
                Price = product.Price,
            };

            if(product.Count > 0)
            {
                result.State = SomeShop.Models.ProductState.Processed;
            }
            else
            {
                result.State = SomeShop.Models.ProductState.NotInStock;
            }


            return result;
        }
        public static List<BLProduct> ConvertEFProducts(List<EFProduct> products)
        {
            List<BLProduct> result = new();


            foreach (EFProduct product in products)
            {
                result.Add(new BLProduct()
                {
                    Id = product.Id,
                    Count = product.Count,
                    Name = product.Name,
                    Price = product.Price,
                });
            }


            return result;
        }

    }
}
