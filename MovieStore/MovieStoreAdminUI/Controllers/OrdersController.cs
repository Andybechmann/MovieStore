using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;

namespace MovieStoreUI.Controllers
{
    public class OrdersController : Controller
    {
        //private MovieStoreDbContext db = new MovieStoreDbContext();
        SampleService service = new SampleService();

        // GET: Orders
        public ActionResult Index()
        {
            //var orders = db.Orders.Include(o => o.Customer).Include(o=>o.OrderLines);
            //List<Order> ordersInList = orders.ToList();
            IEnumerable<Order> orders = service.Orders.GetAll();
            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Order order = db.Orders.Find(id);
            Order order = service.Orders.GetFirst(o => o.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = service.Orders.GetById((int) id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Order order = db.Orders.Find(id);
            //db.Orders.Remove(order);
            //db.SaveChanges();

            service.Orders.Delete(id);
            service.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }
    }
}
