using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MovieStoreDAL.Concrete;

namespace MovieStoreDAL
{

    public class MovieRepository : IRepository<Movie>
    {
        //private MovieStoreDbContext db = new MovieStoreDbContext();
        private readonly SampleEFService _efService;

        public MovieRepository()
        {
            _efService = new SampleEFService();
        }


        public void Add(Movie entity)
        {
            _efService.Movies.Create(entity);
            //using (var db = new MovieStoreDbContext())
            //{
            //    db.Movies.Add(entity);
            //    db.SaveChanges();
            //}
        }


        public void Edit(Movie entity)
        {
            _efService.Movies.Update(entity);
            //db.Entry(entity).State = EntityState.Modified;
            //db.SaveChanges();
        }

        public Movie Get(int id)
        {
            return _efService.Movies.GetById(id);
            //return db.Movies.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _efService.Movies.GetAll();
            //using (var db = new MovieStoreDbContext())
            //{
            //    return db.Movies.ToList();
            //}
        }

        public void Remove(int id)
        {
            _efService.Movies.Delete(id);
            //var a = this.Get(id);
            //db.Movies.Remove(a);
            //db.SaveChanges();
        }

        
    }
}
