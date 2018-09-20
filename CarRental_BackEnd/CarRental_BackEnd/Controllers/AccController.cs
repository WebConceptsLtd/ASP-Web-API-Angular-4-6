
using BO;
using DAL;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http.Results;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;

namespace CarRental_BackEnd.Controllers
{
    public class JwtPacket
    {
        public string Token { get; set; }
        public string UserName { get; set; }
    }

    public class LoginData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/auth")]
    public class AccController : ApiController
    {
        private readonly CarRentalEntities db = new CarRentalEntities();
        //UserManager um = new UserManager();
        [HttpPost]
        [Route("register")]
        public JwtPacket Register([FromBody]User user)
        {
            User newuser = db.Users.Where(a => a.UserName == user.UserName).FirstOrDefault();
            if (newuser != null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            var jwt = new JwtSecurityToken();
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            //var x = um.AddUser(user);
            db.Users.Add(user);
            db.SaveChanges();

            return CreateJwtPacket(user);
            //return new JwtPacket() { Token = encodedJwt, UserName=user.UserName};
        }
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] LoginData loginData)
        {
            User user = db.Users.SingleOrDefault(u => u.UserName == loginData.UserName && u.Password == loginData.Password);

            if (user == null)
                return Content(HttpStatusCode.NotFound, "email or password incorrect");

            return Ok(CreateJwtPacket(user));
        }
        JwtPacket CreateJwtPacket(User user)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is the secret phrase"));

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
              {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
              };
            var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials);

            //var jwt = new JwtSecurityToken();
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtPacket() { Token = encodedJwt, UserName = user.UserName};

        }
    }
}

