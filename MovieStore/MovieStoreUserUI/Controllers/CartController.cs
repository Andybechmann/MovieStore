using MovieStoreUserUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreAdminUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult Delete(int id)
        {
            var line = GetCart().GetOrderLines().FirstOrDefault(x => x.Movie.Id == id);
            if (line != null)
            {
                GetCart().RemoveOrderLine(line);
            }
            return RedirectToAction("index");
        }

        private ShoppingCart GetCart()
        {
            var cart = Session["ShoppingCart"] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session["ShoppingCart"] = cart;
            }
            return cart;
        }
    }
}