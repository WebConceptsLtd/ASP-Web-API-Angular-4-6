using BLL;
using BO;
using CarRental_BackEnd.Helper;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace CarRental_BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/cartype")]
    public class CarTypeController : ApiController
    {
        private CarRentalEntities db = new CarRentalEntities();

        CarTypeManager carTypeManager = new CarTypeManager();

        [HttpGet]
        [Route("all")]
        // GET: api/cartype/all
        public HttpResponseMessage GetAllCars()
        {
            try
            {
                List<CarTypeModel> carType = carTypeManager.GetListOftype();
                return Request.CreateResponse(HttpStatusCode.OK, carType);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpGet]
        [Route("models")]
        public HttpResponseMessage GetListOfModel()
        {
            try
            {
                List<string> b = carTypeManager.GetListOfModel();
                return Request.CreateResponse(HttpStatusCode.OK, b);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("detail/{id}")]
        public HttpResponseMessage GetACartype([FromUri]int id)
        {
            try
            {
                CarTypeModel car = carTypeManager.GetACar(id);
                return Request.CreateResponse(HttpStatusCode.OK, car);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("brand")]
        public HttpResponseMessage GetListOfBrand()
        {
            try
            {
                List<string> b = carTypeManager.GetListOfBrand();
                return Request.CreateResponse(HttpStatusCode.OK, b);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// Post Cartype 
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("post")]

        public HttpResponseMessage PostCar([FromBody]CarType car)
        {
            
            CarTypeModel b = new CarTypeModel
            {
                CarTypeID = car.CarTypeID,
                Brand = car.Brand,
                Model = car.Model,
                PricePerDay = car.PricePerDay,
                PriceExtraPerDay = car.PriceExtraPerDay,
                Year = car.Year,
                IsManual = car.IsManual
            };

            var x = carTypeManager.AddCarType(b);
            return Request.CreateResponse(HttpStatusCode.OK, x);
        }
        /////////////////////////////// PUT: api/Car/5 ///////////////////////////////
        [HttpPut]
        [Route("put/{id}")]
        public IHttpActionResult PutCar([FromUri]int id, [FromBody] CarType cars)
        {

            if (id != cars.CarTypeID)
            {
                return BadRequest();
            }

            db.Entry(cars).State = EntityState.Modified;

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
        [HttpPut]
        [Route("api/cartype/availablecars")]
        [ResponseType(typeof(void))]
        private bool IsAvail(int id)
        {
            using (CarRentalEntities db = new CarRentalEntities())
            {
                {
                    return db.CarTypes.Count(e => e.CarTypeID == id) > 0;
                }
            }
        }

        //[HttpPut]
        //[Route("put/{id}")]
        //public HttpResponseMessage UpdateCar([FromUri]int id,[FromBody]CarTypeModel carModel)
        //{

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            string error = ModelState.Where(ms => ms.Value.Errors.Any()).Select(ms => ms.Value.Errors[0].ErrorMessage).FirstOrDefault();
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
        //        }

        //        carModel = carTypeManager.UpdateCarType(carModel);

        //        return Request.CreateResponse(HttpStatusCode.OK, carModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetInnerMessage(ex));
        //    }

        //}


        //// GET: api/Orders
        //[HttpPut]
        //[Route("put")]
        //public HttpResponseMessage UpdateCarType([FromBody]CarTypeModel cartypeModel)
        //{

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            string error = ModelState.Where(ms => ms.Value.Errors.Any()).Select(ms => ms.Value.Errors[0].ErrorMessage).FirstOrDefault();
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
        //        }

        //        cartypeModel = carTypeManager.UpdateCarType(cartypeModel);

        //        return Request.CreateResponse(HttpStatusCode.OK, cartypeModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetInnerMessage(ex));
        //    }

        //}

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteCar([FromUri]int id)
        {
            try
            {
                if (carTypeManager.DeleteCarType(id))
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
    }
}



