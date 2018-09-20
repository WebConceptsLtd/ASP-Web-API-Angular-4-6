using BLL;
using BO;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http.Cors;
using CarRental_BackEnd.Helper;
using DAL;

namespace CarRental_BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
   // [RoutePrefix("api/order")]
    public class OrdersController : ApiController
    {
        private readonly CarRentalEntities db = new CarRentalEntities();
        OrderManager logic = new OrderManager();

        // GET: api/Orders/id
        [HttpGet]
        [Route("api/order/{id}")]
        public IQueryable<Order> GetOrders(int id)
        {   try
                {
                    Order ord = db.Orders.SingleOrDefault(x => x.OrderID == id);
                    return db.Orders;
                }
                catch (Exception)
                {
                    throw;
                }
            
        }
        [HttpGet]
        [Route("api/order/get/{id}")]
        public HttpResponseMessage GetCarOrder([FromUri]int id)
        {

            try
            {
                OrderModel orders = logic.OrderACar(id);
                return Request.CreateResponse(HttpStatusCode.OK, orders);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
        // GET: api/Orders/all
        [HttpGet]
        [Route("api/order/all")]
        public HttpResponseMessage GetAllOrders()
        {
           
                try
                {
                    List<OrderModel> orders = logic.GetOrders();
                    return Request.CreateResponse(HttpStatusCode.OK, orders);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            
        }

      
        [HttpPost]
        [Route("api/order/post")]
        public HttpResponseMessage PostOrder([FromBody]Order o)
        {
            OrderModel a= new OrderModel
            { 
                OrderID = o.OrderID,
                StartDate = o.StartDate,
               // Returned = o.Returned,
                FinishDate = o.FinishDate,
                UserID=o.UserID,
                CarID=o.CarID
            };


            var x = logic.MakeOrder(a);


            return Request.CreateResponse(HttpStatusCode.OK, x);

        }
        [HttpDelete]
        [Route("api/order/{id}")]
        public HttpResponseMessage DeleteOrder([FromUri]int id)
        {
            try
            {
                if (logic.DeleteOrder(id))
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
        [HttpPost]
        [Route("api/order/price")]
        public HttpResponseMessage FinalPrice([FromUri]Order price, CarType car)
        {
            try
            {
                if(logic.GetFinalPrice(price, car)>0)
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
        //[HttpPost]
        //[Route("makeorder")]
        //public HttpResponseMessage MakeOrder([FromBody]OrderModel orderModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {

            //            string error = ModelState.Where(ms => ms.Value.Errors.Any()).Select(ms => ms.Value.Errors[0].ErrorMessage).FirstOrDefault();
            //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
            //        }

            //        return Request.CreateResponse(HttpStatusCode.Created, orderModel);
            //        //
            //    }
            //    catch (Exception ex)
            //    {
            //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetInnerMessage(ex));
            //    }

            //}

            // GET: api/Orders
        [HttpPut]
        [Route("orders")]
        public HttpResponseMessage UpdateOrder([FromBody]OrderModel orderModel)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    string error = ModelState.Where(ms => ms.Value.Errors.Any()).Select(ms => ms.Value.Errors[0].ErrorMessage).FirstOrDefault();
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
                }

                orderModel = logic.UpdateOrder(orderModel);

                return Request.CreateResponse(HttpStatusCode.OK, orderModel);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetInnerMessage(ex));
            }

        }
    // PUT: api/order/put/5
    [HttpPut]
    [Route("api/order/put/{id}")]
    public IHttpActionResult PutOrder([FromUri]int id, [FromBody] Order order)
    {

      if (id != order.OrderID)
      {
        return BadRequest();
      }

      db.Entry(order).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!IsAvail(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // PUT: api/Orders/5
    //[HttpPut]
    //[Route("edit")]

    //public IHttpActionResult PutOrder(int id, OrderModel order)
    //{

    //        if (!ModelState.IsValid)
    //        {
    //        string error = ModelState.Where(ms => ms.Value.Errors.Any()).Select(ms => ms.Value.Errors[0].ErrorMessage).FirstOrDefault();
    //        return BadRequest(ModelState);
    //        }

    //        if (id != order.OrderID)
    //        {
    //            return BadRequest();
    //        }

    //    order = logic.UpdateOrder(order);

    //    try
    //        {
    //            db.SaveChanges();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!IsAvail(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return StatusCode(HttpStatusCode.NoContent);

    //}


    protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);

        }

        [HttpPut]
        [Route("Availeble")]
        [ResponseType(typeof(void))]
        private bool IsAvail(int id)
        {
            using (CarRentalEntities db = new CarRentalEntities())
            {
                {
                    return db.Orders.Count(e => e.OrderID == id) > 0;
                }
            }
        }
    }
}

