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