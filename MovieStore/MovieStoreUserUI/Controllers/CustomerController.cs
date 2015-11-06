using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Abstarct;
using MovieStoreDAL.Concrete;

namespace MovieStoreAdminUI.Controllers
{
        public class CustomerController : Controller
        {
            //private CustomerRepository cr = new CustomerRepository();
            //private DALFacade df = new DALFacade();
            SampleEFService _efService = new SampleEFService(); 

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
                    _efService.Customers.Create(customer);
                    _efService.Save();
                    //df._customersRepository.Add(customer);

                    return View("CheckEmail");
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
                Customer customer = _efService.Customers.GetById(id);

                 return View(customer);
            }

            // POST: Customers/Edit/5
            [HttpPost]
            public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,Email, EmailConfirm")]
                                        Customer customer)
            {
                try
                {
                    //df._customersRepository.Edit(customer);
                    _efService.Customers.Update(customer);
                    _efService.Save();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(customer);
                }
            }
            [HttpGet]
            public ActionResult CheckEmail()
            {
                return View();
            }
        [HttpPost]
        public ActionResult CheckEmail(string email)
        {
            //Customer customer = df._customersRepository.GetAll().FirstOrDefault(c => c.Email == email);
            Customer customer = _efService.Customers.GetFirst(c => c.Email == email);
            if (customer != null)
            {
                ViewBag.Exist = "Customer with email is exist";
                TempData["customer"] = customer;
            }
            else
            {
                ViewBag.Exist = "Customer with email is not exist";
            }
            return View();
        }

            protected override void Dispose(bool disposing)
            {
                _efService.Dispose();
                base.Dispose(disposing);
            }
        }
    }
