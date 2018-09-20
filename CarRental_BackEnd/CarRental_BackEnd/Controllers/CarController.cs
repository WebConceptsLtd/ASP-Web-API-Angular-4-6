using BO;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;

namespace CarRental_BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/car")]
    public class CarController : ApiController
    {
      
        CarManager logic = new CarManager();
        private CarRentalEntities db = new CarRentalEntities();
        
        [HttpGet]
        [Route("all")]
        // GET: api/Car
        public HttpResponseMessage GetAllCars()
        {
            try
            {
                List<CarModel> cars = logic.GetAllCars();
                return Request.CreateResponse(HttpStatusCode.OK, cars);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET: api/Car/5

        [HttpGet]
        [Route("details/{id}")]
        public HttpResponseMessage GetACar([FromUri]int id)
        {
            try
            {
                CarModel car = logic.GetACar(id);
                return Request.CreateResponse(HttpStatusCode.OK, car);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE: api/Car/
        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteCar([FromUri]int id)
        {
            try
            {
                if (logic.DeleteCar(id))
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        // PUT: api/Car/put/5
        
        [HttpPut]
        [Route("put/{id}")]
        public IHttpActionResult PutCarType([FromUri]int id, [FromBody] Car cartype)
        {

            if (id != cartype.CarID)
            {
                return BadRequest();
            }

            db.Entry(cartype).State = EntityState.Modified;

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


        // POST: api/Car
        [HttpPost]
        [Route("post")]
        public HttpResponseMessage PostCars([FromBody]Car car)
        {
            CarModel u = new CarModel {
             
                CarNum = car.CarNum,
                CarPic = car.CarPic,
                CarTypeID=car.CarTypeID,
                BarnchID=car.BranchID,
                KM = car.KM,
                IsAvailable = car.IsAvailable,
                IsFix = car.IsFix,
            };


            var x = logic.AddCar(u);


            return Request.CreateResponse(HttpStatusCode.OK, x);

        }
        [HttpPut]
        [Route("api/car/availablecar")]
        [ResponseType(typeof(void))]
        private bool IsAvail(int id)
        {
            using (CarRentalEntities db = new CarRentalEntities())
            {
                {
                    return db.Cars.Count(e => e.CarID == id) > 0;
                }
            }
        }
 


    }
}