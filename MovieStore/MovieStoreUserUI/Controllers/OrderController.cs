using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;
using MovieStoreUserUI.Models;

namespace MovieStoreAdminUI.Controllers
{
    public class OrderController : Controller
    {
        //DALFacade _facade = new DALFacade();
        SampleEFService _efService = new SampleEFService();
        
        [HttpGet]
        public ActionResult Buy(ShoppingCart cart)
        {
            Customer customer = (Customer) TempData.Peek("customer");
            int customerId = customer.Id;
            customer = _efService.Customers.GetById(customerId, "Address");
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
            _efService.Orders.Create(order);
            _efService.Save();
            //_facade._orderRepository.Add(order);
            cart.CleanCart();
            return View("Confirmed");
        }

        protected override void Dispose(bool disposing)
        {
            _efService.Dispose();
            base.Dispose(disposing);
        }
    }
}