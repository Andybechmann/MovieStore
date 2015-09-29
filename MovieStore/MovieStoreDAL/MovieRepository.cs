﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieStoreDAL
{

    public class MovieRepository : IRepository<Movie>
    {
        private MovieStoreDbContext db = new MovieStoreDbContext();



        public void Add(Movie entity)
        {
            using (var db = new MovieStoreDbContext())
            {
                db.Movies.Add(entity);
                db.SaveChanges();
            }
        }


        public void Edit(Movie entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Movie Get(int id)
        {
           
            return db.Movies.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies;
        }

        public void Remove(int id)
        {
            var a = this.Get(id);
            db.Movies.Remove(a);
        }

        
    }
}
