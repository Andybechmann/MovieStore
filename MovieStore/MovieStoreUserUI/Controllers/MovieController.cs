using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;

namespace MovieStoreAdminUI.Controllers
{
    public class MovieController : Controller
    {
        DALFacade facade = new DALFacade();
        // GET: Movie
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = facade._moviesRepository.GetAll();
            ShoppingCart shoppingcart = new ShoppingCart();
            shoppingcart.AddOrderLine(new OrderLine() {Amount = 3, Movie = movies.FirstOrDefault() });
            shoppingcart.AddOrderLine(new OrderLine() { Amount = 7, Movie = movies.LastOrDefault() });

            IEnumerable<Customer> customers = facade._customersRepository.GetAll();
            Order order = new Order() {Date = DateTime.Now, Customer = customers.FirstOrDefault(), OrderLines = shoppingcart.GetOrderLines() };

            facade._orderRepository.Add(order);

            return View(facade._moviesRepository.GetAll());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = facade._moviesRepository.Get(id);
            return View(movie);
        }

        
    }
}
