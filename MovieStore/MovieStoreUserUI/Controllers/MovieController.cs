using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Bll.MovieDto;
using MovieStoreDAL.Infrastructure;
using MovieStoreUserUI.Models;

namespace MovieStoreAdminUI.Controllers
{
    public class MovieController : Controller
    {
        
        ServiceGateway<MovieDto> service = new ServiceGateway<MovieDto>("api/movies/");

        public ActionResult Index()
        {
            IEnumerable<MovieDto> movies = service.GetAll();
            return View(service.GetAll());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            MovieDto movie = service.GetOne(id);
            return View(movie);
        }

        public ActionResult AddToCart(ShoppingCart cart, int id)
        {
            MovieDto movie = service.GetOne(id);
            cart.AddOrderLine(movie, 1);

            return RedirectToAction("Index");
        }

    }
}
