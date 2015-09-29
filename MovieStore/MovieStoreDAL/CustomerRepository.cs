using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace MovieStoreDAL
{
    public class CustomerRepository : IRepository<Customer>
    {

        private MovieStoreDbContext db = new MovieStoreDbContext();

        public void Add(Customer entity)
        {
            using (var db = new MovieStoreDbContext())
            {
                db.Customers.Add(entity);
                db.SaveChanges();
            }
        }

        public void Edit(Customer entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Customer Get(int id)
        {
            return db.Customers.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers;
        }

        public void Remove(int id)
        {
            var a = this.Get(id);
            db.Customers.Remove(a);
        }
    }
}