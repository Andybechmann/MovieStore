using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MovieStoreDAL.Concrete;


namespace MovieStoreDAL
{
    public class CustomerRepository : IRepository<Customer>
    {

        //private MovieStoreDbContext db;
        private readonly SampleEFService _efService;

        public CustomerRepository()
        {
            //db = new MovieStoreDbContext();
            _efService = new SampleEFService();
        }
           
        public void Add(Customer entity)
        {
            _efService.Customers.Create(entity);
            //using (var db = new MovieStoreDbContext())
            //{
            //    db.Customers.Add(entity);
            //    db.SaveChanges();
            //}
        }

        public void Edit(Customer entity)
        {
            _efService.Customers.Update(entity);
            //db.Entry(entity).State = EntityState.Modified;
            //var customerAddress = (from a in db.Addresses
            //                      where a.Id == entity.Address.Id
            //                      select a).FirstOrDefault();
            //customerAddress.Streetname = entity.Address.Streetname;
            //customerAddress.ZipCode = entity.Address.ZipCode;
            //customerAddress.City = entity.Address.City;

            //db.Entry(customerAddress).State = EntityState.Modified;

            //db.SaveChanges();
        }

        public Customer Get(int id)
        {
            return _efService.Customers.GetOne(c=> c.Id==id, "Address");
            //return db.Customers.Include("Address").FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _efService.Customers.GetAll();
            //return db.Customers;
        }

        public void Remove(int id)
        {
            _efService.Customers.Delete(id);
            //var customer = this.Get(id);
            //Address address = customer.Address;
            //db.Customers.Remove(customer);
            //db.Addresses.Remove(address);
            //db.SaveChanges();
        }
    }
}