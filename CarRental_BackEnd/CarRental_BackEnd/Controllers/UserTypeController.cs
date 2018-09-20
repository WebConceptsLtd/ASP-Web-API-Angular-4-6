using BLL;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarRental_BackEnd.Controllers

{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/usertype")]
    public class UserTypeController : ApiController
    {
        UserTypeManager usertype = new UserTypeManager();
        [HttpGet]
        [Route("all")]
        // GET: api/usertype/all
        public HttpResponseMessage GetAllCars()
        {
            try
            {
                List<UserTypeModel> ut = usertype.GetTypeOfUser();
                return Request.CreateResponse(HttpStatusCode.OK, ut);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
    }
}
