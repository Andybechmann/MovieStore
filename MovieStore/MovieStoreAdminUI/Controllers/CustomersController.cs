using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;

namespace MovieStoreAdminUI.Controllers
{
    public class CustomersController : Controller
    {
        //private CustomerRepository cr = new CustomerRepository();
        //private DALFacade df = new DALFacade();
        SampleService service = new SampleService();

        // GET: Customers
        public ActionResult Index()
        {
            //IEnumerable<Customer> customers = df._customersRepository.GetAll();
            IEnumerable<Customer> customers = service.Customers.GetAll();
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            //var customer = df._customersRepository.Get(id);
            Customer customer = service.Customers.GetById(id);
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Address,Email,EmailConfirm")]Customer customer)
        {
            try
            {
                //df._customersRepository.Add(customer);
                service.Customers.Create(customer);
                service.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            //Customer customer = df._customersRepository.Get(id);
            Customer customer = service.Customers.GetById(id);
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,Email, EmailConfirm")]Customer customer)
        {
            try
            {
                //df._customersRepository.Edit(customer);
                service.Customers.Update(customer);
                service.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
           //Customer customer = df._customersRepository.Get(id);
            Customer customer = service.Customers.GetById(id);
            return View(customer);
        }

        // POST: Customers/Delete/
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                //Customer customer = df._customersRepository.Get(id);
                //df._customersRepository.Remove(id);
                //Customer customer = service.Customers.GetById(id);
                service.Customers.Delete(id);
                service.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }
    }
}
