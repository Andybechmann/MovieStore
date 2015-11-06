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
        private readonly SampleEFService _efService;

        public OrderRepository()
        {
            _efService = new SampleEFService();
        }

        public void Add(Order entity)
        {
            _efService.Orders.Create(entity);
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
            _efService.Orders.Update(entity);
            //db.Entry(entity).State = EntityState.Modified;
            //db.SaveChanges();
        }

        public Order Get(int id)
        {
            return _efService.Orders.GetById(id);
            //return db.Orders.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _efService.Orders.GetAll();
            //return db.Orders;
        }

        public void Remove(int id)
        {
            _efService.Orders.Delete(id);
            //var a = this.Get(id);
            //db.Orders.Remove(a);
        }
    }
}
