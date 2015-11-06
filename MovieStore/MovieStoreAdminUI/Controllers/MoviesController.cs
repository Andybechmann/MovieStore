using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;


namespace MovieStoreUI.Controllers
{
    public class MoviesController : Controller
    {
        
        //private DALFacade df = new DALFacade();
        private SampleEFService _efService = new SampleEFService();

        // GET: Movies
        public ActionResult Index()
        {
            //var movies = df._moviesRepository.GetAll();
            IEnumerable<Movie> movies = _efService.Movies.GetAll();
            return View(movies);
         
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
          
            //Movie movie = df._moviesRepository.Get(id);
            Movie movie = _efService.Movies.GetById(id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Year,Price,ImageUrl,TrailerUrl,Genre")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //df._moviesRepository.Add(movie);
                _efService.Movies.Create(movie);
                _efService.Save();
             
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {

            //Movie movie = df._moviesRepository.Get(id);
            Movie movie = _efService.Movies.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Year,Price,ImageUrl,TrailerUrl,Genre")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //df._moviesRepository.Edit(movie);
                _efService.Movies.Update(movie);
                _efService.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        //public ActionResult Delete(int id)
        //{

        //    Movie movie = df._moviesRepository.Get(id);
        //    if (movie == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movie);
        //}

        // POST: Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            
            //df._moviesRepository.Remove(id);
            //Movie movie = df._moviesRepository.Get(id);
            _efService.Movies.Delete(id);
            _efService.Save();
            
            TempData["message"] = string.Format("Was deleted");
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _efService.Dispose();
            base.Dispose(disposing);
        }
    }
}
