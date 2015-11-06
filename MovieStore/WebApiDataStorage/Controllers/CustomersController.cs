using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;

namespace WebApiDataStorage.Controllers
{
    public class CustomersController : ApiController
    {
        //private MovieStoreDbContext db = new MovieStoreDbContext();
        SampleEFService service = new SampleEFService();

        // GET: api/Customers
        public HttpResponseMessage GetCustomers()
        {
            try
            {
                IEnumerable<Customer> customers = service.Customers.GetAll();
                if (customers.Count() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customers);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Customers not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }
        }

        // GET: api/Customers/5
        public HttpResponseMessage GetCustomer(int id)
        {
            try
            {
                Customer customer = service.Customers.GetById(id);
                if (customer == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found");
                }

                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        // PUT: api/Customers/5
        public HttpResponseMessage PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState); 
            }
            if (id != customer.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,"Customers id is not the same with given id");
            }

            try
            {
                service.Customers.Update(customer);
                service.Save();
            }
            catch (Exception ex)
            {
                if (!CustomerExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Customer with given id not found");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        // POST: api/Customers
        public HttpResponseMessage PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                customer = service.Customers.Create(customer);
                service.Save();
                var response = Request.CreateResponse(HttpStatusCode.Created, customer);

                string uri = Url.Link("DefaultApi", new {id = customer.Id});
                response.Headers.Location = new Uri(uri); 

                return response;
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message); 
            }
        }

        // DELETE: api/Customers/5
        public HttpResponseMessage DeleteCustomer(int id)
        {
            try
            {
                Customer customer = service.Customers.Delete(id);
                service.Save();
                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return service.Customers.Any(c => c.Id == id);
        }
    }
}