using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;
using MovieStoreDAL.Infrastructure;
using MovieStoreUserUI.Models;

namespace MovieStoreAdminUI.Controllers
{
    public class MovieController : Controller
    {
        //DALFacade facade = new DALFacade();
        // GET: Movie
        //SampleEFService _efService = new SampleEFService();
        ServiceGateway<Movie> service = new ServiceGateway<Movie>("api/orders/");

        public ActionResult Index()
        {
            //return View(facade._moviesRepository.GetAll());
            IEnumerable<Movie> movies = service.GetAll();
            return View(service.GetAll());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            //Movie movie = _efService.Movies.GetById(id);
            Movie movie = service.GetOne(id);
            return View(movie);
        }

        public ActionResult AddToCart(ShoppingCart cart, int Id)
        {
            //Movie movie = _efService.Movies.GetById(Id);
            Movie movie = service.GetOne(Id);
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
            //_efService.Dispose();
            base.Dispose(disposing);
        }
    }
}
