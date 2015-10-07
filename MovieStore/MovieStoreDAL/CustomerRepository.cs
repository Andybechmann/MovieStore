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
            var customerAddress = (from a in db.Addresses
                                  where a.Id == entity.Address.Id
                                  select a).FirstOrDefault();
            customerAddress.Streetname = entity.Address.Streetname;
            customerAddress.ZipCode = entity.Address.ZipCode;
            customerAddress.City = entity.Address.City;

            db.Entry(customerAddress).State = EntityState.Modified;

            db.SaveChanges();
        }

        public Customer Get(int id)
        {
            return db.Customers.Include("Address").FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers;
        }

        public void Remove(int id)
        {
            var customer = this.Get(id);
            Address address = customer.Address;
            db.Customers.Remove(customer);
            db.Addresses.Remove(address);
            db.SaveChanges();
        }
    }
}