using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;

namespace MovieStoreUserUI.Models
{
    public class MovieViewModel
    {
        //DALFacade repository = new DALFacade();
        SampleService service = new SampleService();

        public IEnumerable<Movie> Movies
        {
            get { return service.Movies.GetAll(); }
        }

        public Movie SelectedMovie { get; set; }

        public void SetSelectedMovie(int? id)
        {
            SelectedMovie = (id != null) ?
                Movies.First(a => a.Id == id) :Movies.First();
        }

    }
}