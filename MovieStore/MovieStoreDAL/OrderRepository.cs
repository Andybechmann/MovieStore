using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MovieStoreDAL.Concrete;

namespace MovieStoreDAL
{
    public class OrderRepository : IRepository<Order>
    {
        //private MovieStoreDbContext db = new MovieStoreDbContext();
        private readonly SampleService service;

        public OrderRepository()
        {
            service = new SampleService();
        }

        public void Add(Order entity)
        {
            service.Orders.Create(entity);
            //using (var db = new MovieStoreDbContext())
            //{
            //    entity.OrderLines.ForEach(x=> db.Movies.Attach(x.Movie));
            //    db.Customers.Attach(entity.Customer);
            //    db.Orders.Add(entity);
            //    db.SaveChanges();
            //}
        }

        public void Edit(Order entity)
        {
            service.Orders.Update(entity);
            //db.Entry(entity).State = EntityState.Modified;
            //db.SaveChanges();
        }

        public Order Get(int id)
        {
            return service.Orders.GetById(id);
            //return db.Orders.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return service.Orders.GetAll();
            //return db.Orders;
        }

        public void Remove(int id)
        {
            service.Orders.Delete(id);
            //var a = this.Get(id);
            //db.Orders.Remove(a);
        }
    }
}
