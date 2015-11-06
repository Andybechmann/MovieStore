using MovieStoreUserUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;

namespace MovieStoreAdminUI.Controllers
{
    public class CartController : Controller
    {
        //DALFacade facade = new DALFacade();
        SampleService service = new SampleService();
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

        public ActionResult AddAmount(int id)
        {

            //var movie = facade._moviesRepository.Get(id);
            Movie movie = service.Movies.GetById(id);
            //var cart = GetCart();

            GetCart().AddOrderLine(movie, 1);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveAmount(int id)
        {
            //var movie = facade._moviesRepository.Get(id);
            //var cart = GetCart();
            Movie movie = service.Movies.GetById(id);
            GetCart().RemoveAmount(movie, 1);

            return RedirectToAction("Index");
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

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }
    }
}