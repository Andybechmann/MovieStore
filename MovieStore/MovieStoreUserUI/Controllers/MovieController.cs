using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreUserUI.Models;

namespace MovieStoreAdminUI.Controllers
{
    public class MovieController : Controller
    {
        DALFacade facade = new DALFacade();
        // GET: Movie
        public ActionResult Index()
        {
            return View(facade._moviesRepository.GetAll());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = facade._moviesRepository.Get(id);
            return View(movie);
        }
<<<<<<< HEAD
=======

     

        public ActionResult AddToCart(int id)
        {
            var movie = facade._moviesRepository.Get(id);
            var cart = GetCart();
            cart.AddOrderLine(movie, 1);

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


>>>>>>> f797d5c65e48067010c3f02b0b03fedb874a4dfa
    }
}
