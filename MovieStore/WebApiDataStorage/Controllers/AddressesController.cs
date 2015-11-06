using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieStoreDAL;
using MovieStoreDAL.Concrete;

namespace WebApiDataStorage.Controllers
{
    public class AddressesController : ApiController
    {
        SampleEFService service = new SampleEFService();

        // GET: api/Addresses
        public HttpResponseMessage GetAddresses()
        {
            try
            {
                IEnumerable<Address> addresses = service.Addresses.GetAll();
                if (addresses.Count() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, addresses);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Addresses not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: api/Addresses/5
        public HttpResponseMessage GetCustomer(int id)
        {
            try
            {
                Address address = service.Addresses.GetById(id);
                if (address == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Address not found");
                }

                return Request.CreateResponse(HttpStatusCode.OK, address);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        // PUT: api/Addresses/5
        public HttpResponseMessage PutCustomer(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != address.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Addresses id is not the same with given id");
            }

            try
            {
                service.Addresses.Update(address);
                service.Save();
            }
            catch (Exception ex)
            {
                if (!CustomerExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Address with given id not found");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, address);
        }

        // POST: api/Addresses
        public HttpResponseMessage PostCustomer(Address address)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                address = service.Addresses.Create(address);
                service.Save();
                var response = Request.CreateResponse(HttpStatusCode.Created, address);

                string uri = Url.Link("DefaultApi", new { id = address.Id });
                response.Headers.Location = new Uri(uri);

                return response;
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Addresses/5
        public HttpResponseMessage DeleteCustomer(int id)
        {
            try
            {
                Address address = service.Addresses.Delete(id);
                service.Save();
                return Request.CreateResponse(HttpStatusCode.OK, address);
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
            return service.Addresses.Any(c => c.Id == id);
        }
    }
}
