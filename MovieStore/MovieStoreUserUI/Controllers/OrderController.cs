using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreUserUI.Models;

namespace MovieStoreAdminUI.Controllers
{
    public class OrderController : Controller
    {
        DALFacade _facade = new DALFacade();
        
        [HttpGet]
        public ActionResult Buy(ShoppingCart cart)
        {
            Customer customer = (Customer) TempData.Peek("customer");
            cart.Customer = customer;

            return View(cart);
        }
        [HttpPost,ActionName("Buy")]
        
        public ActionResult BuyConfirmed(ShoppingCart cart)
        {
            Customer customer = (Customer) TempData["customer"];
            Order order = new Order
            {
                Customer = customer,
                CustomerId = customer.Id,
                Date = DateTime.Now,
                OrderLines = cart.orderLines
            };
            _facade._orderRepository.Add(order);
            return View("Confirmed");
        }


    }
}