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
    public class OrdersController : ApiController
    {
        SampleEFService service = new SampleEFService();

        // GET: api/Orders
        public HttpResponseMessage GetOrders()
        {
            try
            {
                IEnumerable<Order> orders = service.Orders.GetAll();
                if (orders.Count() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, orders);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Orders not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: api/Orders/5
        public HttpResponseMessage GetOrder(int id)
        {
            try
            {
                Order order = service.Orders.GetOne(o => o.Id == id);
                if (order == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Order not found");
                }

                return Request.CreateResponse(HttpStatusCode.OK, order);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        // PUT: api/Orders/5
        public HttpResponseMessage PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != order.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Orders id is not the same with given id");
            }

            try
            {
                service.Orders.Update(order);
                service.Save();
            }
            catch (Exception ex)
            {
                if (!OrderExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Order with given id not found");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, order);
        }

        // POST: api/Orders
        public HttpResponseMessage PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                order = service.Orders.Create(order);
                service.Save();
                var response = Request.CreateResponse(HttpStatusCode.Created, order);

                string uri = Url.Link("DefaultApi", new { id = order.Id });
                response.Headers.Location = new Uri(uri);

                return response;
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Orders/5
        public HttpResponseMessage DeleteOrder(int id)
        {
            try
            {
                Order order = service.Orders.Delete(id);
                service.Save();
                return Request.CreateResponse(HttpStatusCode.OK, order);
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

        private bool OrderExists(int id)
        {
            return service.Orders.Any(c => c.Id == id);
        }
    }
}
