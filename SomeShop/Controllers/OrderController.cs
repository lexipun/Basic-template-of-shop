
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBussinesLogic.Models;
using ShopBussinesLogic.ProductOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeShop.Controllers
{
    public class OrderController : Controller
    {
        private static readonly string OrderKey = "OrderId";
        private static BasicCRUD operationsWithModels = new();

        public ILogger<OrderController> Logger {get;}

        public OrderController(ILogger<OrderController> logger)
        {
            Logger = logger;
        }

        public IActionResult Add(int productId, int count = 1)
        {
            int orderId;
            string stringOrderId;

            if (!HttpContext.Request.Cookies.ContainsKey(OrderKey))
            {
                orderId = operationsWithModels.CreateOrder();
                HttpContext.Response.Cookies.Append(OrderKey, orderId.ToString());
                Logger.LogInformation("order waith id={0} was created", orderId);

                stringOrderId = orderId.ToString();
            }
            else
            {
                HttpContext.Request.Cookies.TryGetValue(OrderKey, out stringOrderId);
                Logger.LogInformation("user who has order (id = {0}) opened program", stringOrderId);
            }

            orderId = int.Parse(stringOrderId);

            operationsWithModels.SetProductOrder(productId, count, orderId);
            return NoContent();

        }

        public IActionResult Get()
        {
            int orderId;

            if (!HttpContext.Request.Cookies.TryGetValue(OrderKey, out string stringOrderId))
            {
                return View();
            }

            orderId = int.Parse(stringOrderId);

            Order order = operationsWithModels.GetOrderById(orderId);

            return View(order);
        }

        public IActionResult Buy(string email, string adress)
        {
            int orderId;

            if (!HttpContext.Request.Cookies.TryGetValue(OrderKey, out string stringOrderId))
            {
                return NoContent();
            }

            orderId = int.Parse(stringOrderId);
            operationsWithModels.FillOrder(email, adress, orderId);

            if (operationsWithModels.RemoveOrderById(orderId))
            {
                HttpContext.Response.Cookies.Delete(stringOrderId);
                Logger.LogInformation("user with order (id = {0}) bought part products", orderId);
                return Ok("You bought part of products \n  you will recieve email about available other products");
            }

            Logger.LogInformation("user with order (id = {0}) bought products and order was removed", orderId);
            return Ok("You bought all products;");
        }

        public IActionResult Subscribe(string email)
        {
            int orderId;

            if (!HttpContext.Request.Cookies.TryGetValue(OrderKey, out string stringOrderId))
            {
                return NoContent();
            }

            orderId = int.Parse(stringOrderId);
            operationsWithModels.FillOrder(email, string.Empty, orderId);

            Logger.LogInformation("user with order (id = {0}) was subscribed to new products", orderId);

            return Ok("You will recieve email about available products");
        }
    }
}
