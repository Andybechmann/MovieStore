using MovieStoreUserUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Bll.MovieDto;
using MovieStoreDAL.Concrete;
using MovieStoreDAL.Infrastructure;

namespace MovieStoreAdminUI.Controllers
{
    public class CartController : Controller
    {
        //DALFacade facade = new DALFacade();
        //SampleEFService _efService = new SampleEFService();
        ServiceGateway<MovieDto> service = new ServiceGateway<MovieDto>("api/movies/");


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
            MovieDto movie = service.GetOne(id);
            //Movie movie = _efService.Movies.GetById(id);
            //var cart = GetCart();

            GetCart().AddOrderLine(movie, 1);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveAmount(int id)
        {
            //var movie = facade._moviesRepository.Get(id);
            //var cart = GetCart();
            MovieDto movie = service.GetOne(id);
            //Movie movie = _efService.Movies.GetById(id);
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
        }
}