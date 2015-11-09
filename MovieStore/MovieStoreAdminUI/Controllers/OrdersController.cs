using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;
using MovieStoreDAL.Infrastructure;

namespace MovieStoreUI.Controllers
{
    public class OrdersController : Controller
    {
        //SampleEFService _efService = new SampleEFService();
        ServiceGateway<Order> service = new ServiceGateway<Order>("api/orders/");

        // GET: Orders
        public ActionResult Index()
        {
            IEnumerable<Order> orders = service.GetAll();
            //IEnumerable<Order> orders = _efService.Orders.GetAll();
            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = service.GetOne((int)id);
            //Order order = _efService.Orders.GetFirst(o => o.Id == id);
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
            Order order = service.GetOne((int)id);
            //Order order = _efService.Orders.GetById((int) id);
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

            service.Delete(id);
            //_efService.Orders.Delete(id);
            //_efService.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //_efService.Dispose();
            base.Dispose(disposing);
        }
    }
}
