using BLL;
using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Data.Entity;
using CarRental_BackEnd.Helper;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.Entity.Infrastructure;

namespace CarRental_BackEnd.Controllers
{

  [EnableCors("*", "*", "*")]

  public class UserController : ApiController
  {
    private readonly CarRentalEntities db = new CarRentalEntities();
    UserManager um = new UserManager();

    /// //////////////////     // GET: api/user/all //////////////////////

    [HttpGet]
    [Route("api/user/all")]
    public HttpResponseMessage GetAllUsers()
    {
      try
      {
        List<UserModel> users = um.GetAllUsers();
        return Request.CreateResponse(HttpStatusCode.OK, users);
      }
      catch (Exception ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
      }

    }
        //////////////////////   // GET: api/User/{name}   //////////////////////////////
        [HttpGet]
        [Route("api/user/details")]
        public HttpResponseMessage GetAUser([FromUri]string userName)
        {
            try
            {
                UserModel user = um.GetAUser(userName);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
            [HttpPost]
        [Route("api/user/imgpath")]
        public HttpResponseMessage UploadJsonFile([FromBody] User user)
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                    }
                }
                return response;
            }
        
        [HttpGet]
    [Route("api/user/{name}")]
    public HttpResponseMessage GetUser([FromUri]string name)
    {
      try
      {
        UserModel user = um.GetUserName(name);
        return Request.CreateResponse(HttpStatusCode.OK, user);
      }
      catch (Exception ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
      }
    }
    [HttpGet]
    [Route("api/user/fullname")]
    public HttpResponseMessage GetFullName()
    {
      try
      {
        List<string> un = um.GetUserByFullName();
        return Request.CreateResponse(HttpStatusCode.OK, un);
      }
      catch (Exception ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
      }
    }
    [HttpGet]
    [Route("api/user/username")]
    public HttpResponseMessage GetUserName()
    {
      try
      {
        List<string> un = um.GetUserByUserName();
        return Request.CreateResponse(HttpStatusCode.OK, un);
      }
      catch (Exception ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
      }
    }
    //////////////////////   DELETE: api/User/ delete by name  //////////////////////////////
    [HttpDelete]
    [Route("api/user/{id}")]
    public HttpResponseMessage DeleteUser([FromUri]int id)
    {
      try
      {
        if (um.DeleteUser(id))
          return Request.CreateResponse(HttpStatusCode.OK, true);
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError());
      }
      catch (Exception ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
      }

    }

        [HttpPost]
        [Route("api/user/post1")]

        public HttpResponseMessage PostUser1([FromBody]User user)
        {

            UserModel u = new UserModel {
                Birthday = user.Birthday,
                Email = user.Email,
                FullName = user.FullName,
                Gender = user.Gender,
                IsValidUSer = user.IsValidUSer,
                Password = user.Password,
                TeudatZeut = user.TeudatZeut,
                UserName = user.UserName,
                 UserTypeID = user.UserTypeID
           };


            var x = um.AddUser(u);

            return Request.CreateResponse(HttpStatusCode.OK, x);


        }

        public class EditProfileData
        {
            public string FullName { get; set; }
            public string Email { get; set; }
        }


    /////////////////////////////// PUT: api/User/5 ///////////////////////////////
    // PUT api/user/put/5
    [HttpPut]
    [Route("api/user/put/{id}")]
    public IHttpActionResult PutUser([FromUri]int id, [FromBody] User user)
    {

      if (id != user.UserID)
      {
        return BadRequest();
      }

      db.Entry(user).State = EntityState.Modified;

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

        [HttpPost]
        [Route("api/user/post2")]

        public IHttpActionResult Post([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);

            User u = new User
            {
                Birthday = user.Birthday,
                Email = user.Email,
                FullName = user.FullName,
                Gender = user.Gender,
                IsValidUSer = user.IsValidUSer,
                Password = user.Password,
                TeudatZeut = user.TeudatZeut,
                UserName = user.UserName,
                UserTypeID = user.UserTypeID,
                Phone=user.Phone,
                PicPath=imageName
            };


            db.Users.Add(u);
            db.SaveChanges();

            return Ok();

        }

        [HttpPost]
    [Route("api/user/uploadImage")]
    public HttpResponseMessage UploadImage()
    {
      string imageName = null;
      var httpRequest = HttpContext.Current.Request;
      //Upload Image
      var postedFile = httpRequest.Files["Image"];
      //Create custom filename
      imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
      imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
      var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
      postedFile.SaveAs(filePath);

      User image = new User()
      {
        PicPath = imageName
      };
      db.Users.Add(image);
      db.SaveChanges();

      return Request.CreateResponse(HttpStatusCode.Created);
    }

    [HttpPut]
    [Route("api/user/availuser")]
    [ResponseType(typeof(void))]
    private bool IsAvail(int id)
    {
      using (CarRentalEntities db = new CarRentalEntities())
      {
        {
          return db.Users.Count(e => e.UserID == id) > 0;
        }
      }
    }


  }
}

