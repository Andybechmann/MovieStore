using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;

namespace MovieStoreAdminUI.Controllers
{
    public class OrderController : Controller
    {
        DALFacade _facade = new DALFacade();
        
        // I Constructor
        //if(Session["cart"] == null)
        //    Session["cart"] = new List<ShoppingcartItem>();
        
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            Movie movie = _facade._moviesRepository.Get(id);
            return View(movie);
        }



    }
}