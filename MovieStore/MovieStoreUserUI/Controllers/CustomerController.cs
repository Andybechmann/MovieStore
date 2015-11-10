using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreDAL;
using MovieStoreDAL.Abstarct;
using MovieStoreDAL.Concrete;
using MovieStoreDAL.Infrastructure;

namespace MovieStoreAdminUI.Controllers
{
        public class CustomerController : Controller
        {
        //private CustomerRepository cr = new CustomerRepository();
        //private DALFacade df = new DALFacade();

        ServiceGateway<Customer> service = new ServiceGateway<Customer>("api/movies/");

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
                    service.CreateOne(customer);
                    //_efService.Customers.Create(customer);
                    //_efService.Save();
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
                //Customer customer = _efService.Customers.GetById(id);
                Customer customer = service.GetOne(id);

                 return View(customer);
            }

            // POST: Customers/Edit/5
            [HttpPost]
            public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,Email, EmailConfirm")]
                                        Customer customer)
            {
                try
                {
                    service.Update(customer);
                    //_efService.Customers.Update(customer);
                    //_efService.Save();
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
            //Customer customer = _efService.Customers.GetFirst(c => c.Email == email);
            IEnumerable<Customer> customers = service.GetAll();
            Customer customer = null;
            foreach (Customer customer1 in customers)
            {
                if (customer1.Email == email)
                    customer = customer1;
            } 

        
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
        }
    }
