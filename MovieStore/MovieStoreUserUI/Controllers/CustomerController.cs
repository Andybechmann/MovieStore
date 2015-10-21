using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;

namespace MovieStoreAdminUI.Controllers
{
    public class CustomerController : Controller
    {
        public class CustomersController : Controller
        {
            //private CustomerRepository cr = new CustomerRepository();
            private DALFacade df = new DALFacade();

            // GET: Customers
            public ActionResult Index()
            {
                IEnumerable<Customer> customer = df._customersRepository.GetAll();
                return View(customer);
            }

            // GET: Customers/Details/5
            public ActionResult Details(int id)
            {
                var customer = df._customersRepository.Get(id);
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
                    df._customersRepository.Add(customer);

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
                Customer customer = df._customersRepository.Get(id);
                return View(customer);
            }

            // POST: Customers/Edit/5
            [HttpPost]
            public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,Email, EmailConfirm")]Customer customer)
            {
                try
                {
                    df._customersRepository.Edit(customer);

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
                Customer customer = df._customersRepository.Get(id);
                return View(customer);
            }

            // POST: Customers/Delete/
            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                try
                {
                    Customer customer = df._customersRepository.Get(id);
                    df._customersRepository.Remove(id);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }
    }
}