
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data.Entity;
using BLL;
using BO;
using CarRental_BackEnd.Helper;
using DAL;
using System.Linq;

namespace CarRental_BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/branch")]
    public class BranchController : ApiController
    {

        //branchMg 
        BranchManager branchMg = new BranchManager();
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllBranches()
        {
            try
            {
                List<BranchModel> branches = branchMg.GetBranches();
                return Request.CreateResponse(HttpStatusCode.OK, branches);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("names")]
        public HttpResponseMessage GetBranchesName()
        {
            try
            {
                List<string> branches = branchMg.GetBranchesName();
                return Request.CreateResponse(HttpStatusCode.OK, branches);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("location")]
        public HttpResponseMessage GetBrancheAddress()
        {
            try
            {
                List<string> branches = branchMg.GetBranchesName();
                return Request.CreateResponse(HttpStatusCode.OK, branches);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("post")]
        public HttpResponseMessage PostBranch([FromBody]Branch br)
        {

           BranchModel bm = new BranchModel
            {
              BranchID=br.BranchID,
              Name=br.Name,
              Address=br.Address,
              Latitude=br.Latitude, 
              Longtitude=br.Longtitude
            };

            var x = branchMg.AddBranch(bm);
            return Request.CreateResponse(HttpStatusCode.OK, x);
        }

        // GET: api/Branchs
        [HttpPut]
        [Route("put")]
        public HttpResponseMessage UpdateBranch([FromBody]BranchModel branchModel)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    string error = ModelState.Where(ms => ms.Value.Errors.Any()).Select(ms => ms.Value.Errors[0].ErrorMessage).FirstOrDefault();
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
                }

                branchModel = branchMg.UpdateBranch(branchModel);

                return Request.CreateResponse(HttpStatusCode.OK, branchModel);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ExceptionHelper.GetInnerMessage(ex));
            }

        }
        [HttpDelete]
        [Route("{name}")]
        public HttpResponseMessage DeleteBranch([FromUri]string name)
        {
            try
            {
                if (branchMg.DeleteBranch(name))
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