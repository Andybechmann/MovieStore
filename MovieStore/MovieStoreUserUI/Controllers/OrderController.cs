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
            Customer customer = (Customer) TempData["customer"];
            cart.Customer = customer;

            return View();
        }
        

    }
}