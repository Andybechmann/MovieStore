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
        private readonly SampleService service;

        public CustomerRepository()
        {
            //db = new MovieStoreDbContext();
            service = new SampleService();
        }
           
        public void Add(Customer entity)
        {
            service.Customers.Create(entity);
            //using (var db = new MovieStoreDbContext())
            //{
            //    db.Customers.Add(entity);
            //    db.SaveChanges();
            //}
        }

        public void Edit(Customer entity)
        {
            service.Customers.Update(entity);
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
            return service.Customers.GetById(id,"Address");
            //return db.Customers.Include("Address").FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return service.Customers.GetAll();
            //return db.Customers;
        }

        public void Remove(int id)
        {
            service.Customers.Delete(id);
            //var customer = this.Get(id);
            //Address address = customer.Address;
            //db.Customers.Remove(customer);
            //db.Addresses.Remove(address);
            //db.SaveChanges();
        }
    }
}