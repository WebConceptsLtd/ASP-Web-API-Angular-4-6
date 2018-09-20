
using System;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BO;
using System.Security.Claims;
using System.Collections.Generic;
using DAL;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;
namespace CarRental_BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/user/register")]
    public class RgistrationController : ApiController
    {
        
        private readonly CarRentalEntities db = new CarRentalEntities();
        // POST api/user/register
        
       
        [HttpPost]
        [Route("registeration")]
        public bool EditUserRgistrationForm([FromBody] UserModel usermastertb)
        {
            try
            {

                var output = (from usermaster in db.Users
                              where usermastertb.UserID== usermaster.UserID
                              select usermaster.UserName).Count();

                if (output > 0)
                {
                    return false;
                }
                else
                {
                    var userTypeID = (from user in db.UserTypes
                                      where user.TypeOfUser =="Admin"
                                      select user.UserTypeID).SingleOrDefault();

                    //  usermastertb.UserTypeID = User.GetType;
                    
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(RegisterModel model)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser()
            {
                UserID= model.UserID,
                UserName = model.UserName,
                Email = model.Email,
              

            };
            user.FullName = model.FullName;
            user.Gender= model.Gender;
            user.BirthDate = model.Birthday;
            user.TeudatZeut = model.TeudatZeut;
            user.Password = model.Password;
           
           

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6
            };
            IdentityResult result = manager.Create(user, model.Password);
            return result;
        }

        [HttpGet]
        [Route("getUserClaims")]
        public RegisterModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            RegisterModel model = new RegisterModel()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FullName = identityClaims.FindFirst("FullName").Value,
                Gender = identityClaims.FindFirst("Gender").Value,
                Password = identityClaims.FindFirst("Password").Value,
                
             
            };
            return model;
        }

        //[Route("api/User/Register")]
        //[HttpPost]
        //public IdentityResult EditUserRgistrationForm(RegisterModel model)
        //{

        //    var userAdmin = new UserStore<ApplicationUser>(new ApplicationDbContext());
        //    var manager = new UserManager<ApplicationUser>(userAdmin);
        //    var user = new User()
        //    {
        //        UserID=model.UserID,
        //        UserName = model.UserName,
        //        Birthday=model.Birthday,
        //        FullName=model.FullName,
        //        Gender=model.Gender,
        //        TeudatZeut=model.TeudatZeut,
        //        Password=model.Password,
        //        Email = model.Email
                
        //    };
        //    user.UserID = model.UserID;
        //    user.UserName = model.UserName;
        //    user.FullName = model.FullName;
        //    user.Gender = model.Gender;
        //    user.Birthday = model.Birthday;
        //    user.TeudatZeut = model.TeudatZeut;
        //    user.Email = model.Email;
        //    user.Password = model.Password;
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 6
        //    };
        //    IdentityResult result = model.Create(user.Password);
        //    return result;
        //}


    }
}

