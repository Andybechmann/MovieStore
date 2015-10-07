using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;

namespace MovieStoreUserUI.Models
{
    public class MovieViewModel
    {
        DALFacade repository = new DALFacade();

        public IEnumerable<Movie> Movies
        {
            get { return repository._moviesRepository.GetAll(); }
        }

        public Movie SelectedMovie { get; set; }

        public void SetSelectedMovie(int? id)
        {
            SelectedMovie = (id != null) ?
                Movies.First(a => a.Id == id) :Movies.First();
        }

    }
}