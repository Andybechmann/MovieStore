using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;

namespace WebApiDataStorage.Controllers
{
    public class MoviesController : ApiController
    {
        SampleEFService service = new SampleEFService();

        // GET: api/Movies
        public HttpResponseMessage GetMovies()
        {
            try
            {
                IEnumerable<Movie> movies = service.Movies.GetAll();
                var enumerable = movies as IList<Movie> ?? movies.ToList();
                if (enumerable.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, enumerable);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Movies not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: api/Movies/5
        public HttpResponseMessage GetMovie(int id)
        {
            try
            {
                Movie movie = service.Movies.GetById(id);
                if (movie == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Movie not found");
                }

                return Request.CreateResponse(HttpStatusCode.OK, movie);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        // PUT: api/Movies/5
        public HttpResponseMessage PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != movie.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Movies id is not the same with given id");
            }

            try
            {
                service.Movies.Update(movie);
                service.Save();
            }
            catch (Exception ex)
            {
                if (!MovieExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Movie with given id not found");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, movie);
        }

        // POST: api/Movies
        public HttpResponseMessage PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                movie = service.Movies.Create(movie);
                service.Save();
                var response = Request.CreateResponse(HttpStatusCode.Created, movie);

                string uri = Url.Link("DefaultApi", new { id = movie.Id });
                response.Headers.Location = new Uri(uri);

                return response;
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Movies/5
        public HttpResponseMessage DeleteMovie(int id)
        {
            try
            {
                Movie movie = service.Movies.Delete(id);
                service.Save();
                return Request.CreateResponse(HttpStatusCode.OK, movie);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return service.Movies.Any(c => c.Id == id);
        }
    }
}
