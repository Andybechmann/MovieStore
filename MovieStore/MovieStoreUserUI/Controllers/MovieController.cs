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
    public class MovieController : Controller
    {
        //DALFacade facade = new DALFacade();
        // GET: Movie
        SampleService service = new SampleService();

        public ActionResult Index()
        {
            //return View(facade._moviesRepository.GetAll());
            return View(service.Movies.GetAll());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            //Movie movie = facade._moviesRepository.Get(movieId);
            Movie movie = service.Movies.GetById(id);
            return View(movie);
        }

        public ActionResult AddToCart(ShoppingCart cart, int Id)
        {
            //var movie = facade._moviesRepository.Get(movieId);
            Movie movie = service.Movies.GetById(Id);

            //var cart = GetCart();
            cart.AddOrderLine(movie, 1);

            return RedirectToAction("Index");
        }


        //private ShoppingCart GetCart()
        //{
        //    var cart = Session["ShoppingCart"] as ShoppingCart;
        //    if (cart == null)
        //    {
        //        cart = new ShoppingCart();
        //        Session["ShoppingCart"] = cart;
        //    }
        //    return cart;
        //}

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }
    }
}
