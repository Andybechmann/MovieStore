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
            facade._moviesRepository.GetAll();
            return View(facade._moviesRepository.GetAll());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
    }
}
