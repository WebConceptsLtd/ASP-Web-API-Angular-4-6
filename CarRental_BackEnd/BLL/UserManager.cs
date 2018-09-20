using BO;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager : DALBase
    {
        public bool AddUser(UserModel useradd)
        {
            using (CarRentalEntities db = new CarRentalEntities())
            {
                User newuser = db.Users.Where(a => a.UserID == useradd.UserID).FirstOrDefault();
                if (newuser != null)
                {
                    return false;
                }

            };

            User u = new User
            {
                //UserID = useradd.UserID,
                FullName = useradd.FullName,
                TeudatZeut = useradd.TeudatZeut,
                UserName = useradd.UserName,
                Email = useradd.Email,
                Gender = useradd.Gender,
                Password = useradd.Password,

                IsValidUSer = useradd.IsValidUSer,
                //PicPath = useradd.PicPath,
                Birthday = useradd.Birthday,
                //UserTypeID = useradd.UserTypeID

            };

            try

            {
                db.Users.Add(u);
                db.SaveChanges();
                var typeofuser = db.Users.Where(x => x.UserTypeID == u.UserTypeID).FirstOrDefault();
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);
                ApplicationUser uIdentity = new ApplicationUser
                {
                    UserID = useradd.UserID,
                    BirthDate = useradd.Birthday,
                    UserTypeID = useradd.UserTypeID,
                    FullName = useradd.FullName,
                    TeudatZeut = useradd.TeudatZeut,
                    UserName = useradd.UserName,
                    Email = useradd.Email,
                    Gender = useradd.Gender,
                    Password = useradd.Password,
                    IsValidUSer = useradd.IsValidUSer,
                    PicPath = useradd.PicPath,
                    Phone = useradd.Phone

                    // TypeOfUser = typeofuser.UserType.TypeOfUser
                };
                //IdentityResult identified = userManager.Create(uIdentity, useradd.Password);

                return true;

            }
            catch (System.Data.Entity.Core.UpdateException)
            {
                return false;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException) //DbContext
            {
                return false;
            }

        }

        public UserModel GetUserName(string name)
        {

            using (CarRentalEntities db = new CarRentalEntities())
            {
                User ur = db.Users.FirstOrDefault(b => b.UserName == name);

                if (ur != null)
                {
                    db.Users.Where(x => x.IsValidUSer == true).ToList();

                }

                return null;
            }
        }
        public UserModel GetAUser(string userName)
        {
            User useradd = db.Users.FirstOrDefault(b => b.UserName == userName);

            if (useradd != null)
            {
                return new UserModel
                {
                    UserID = useradd.UserID,
                    Birthday = useradd.Birthday,
                    UserTypeID = useradd.UserTypeID,
                    FullName = useradd.FullName,
                    TeudatZeut = useradd.TeudatZeut,
                    UserName = useradd.UserName,
                    Email = useradd.Email,
                    Gender = useradd.Gender,
                    Password = useradd.Password,
                    IsValidUSer = useradd.IsValidUSer,
                    PicPath = useradd.PicPath,
                    Phone = useradd.Phone
                };
            }
            return null;
        }
        public List<UserModel> GetAllUsers()
        {
            return db.Users.Select(ur => new UserModel
            {
                UserID = ur.UserID,
                FullName = ur.FullName,
                TeudatZeut = ur.TeudatZeut,
                UserName = ur.UserName,
                Birthday = ur.Birthday,
                UserTypeID = ur.UserTypeID,
                Email = ur.Email,
                Gender = ur.Gender,
                IsValidUSer = ur.IsValidUSer,
                Password = ur.Password,
                PicPath = ur.PicPath,
                Phone = ur.Phone,


            }).ToList();



        }
        public List<string> GetUserByFullName()
        {
            return db.Users.Select(a => a.FullName).ToList();
        }

        public List<string> GetUserByUserName()
        {
            return db.Users.Select(a => a.UserName).ToList();
        }

        public bool EditUsersPassword(UserModel user, LoginModel password)
        {
            using (CarRentalEntities db = new CarRentalEntities())
            {
                User u = db.Users.FirstOrDefault(a => a.UserName == user.UserName && a.Password == password.Password);

                if (u != null)
                {
                    u.Password = password.Password;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }






        //    public bool AddUser(UserModel useradd)
        //{
        //  User newuser = db.Users.Where(a => a.UserID == useradd.UserID).FirstOrDefault();
        //  if (newuser != null)
        //  {
        //    return false;
        //  }


        //  User u = new User
        //  {
        //    FullName = useradd.FullName,
        //    TeudatZeut = useradd.TeudatZeut,
        //    UserName = useradd.UserName,
        //    Email = useradd.Email,
        //    Gender = useradd.Gender,
        //    Password = useradd.Password,
        //    Phone = useradd.Phone,
        //    IsValidUSer = useradd.IsValidUSer,
        //    PicPath = useradd.PicPath,
        //    Birthday = useradd.Birthday,

        //    UserTypeID = useradd.UserType.UserTypeID
        //  };


        //  {
        //    db.Users.Add(u);
        //    db.SaveChanges();
        //    var typeofuser = db.Users.Where(x => x.UserType.UserTypeID == u.UserTypeID).FirstOrDefault();
        //    var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
        //    var userManager = new UserManager<ApplicationUser>(userStore);
        //    ApplicationUser uIdentity = new ApplicationUser
        //    {
        //      UserID = useradd.UserID,
        //      BirthDate = useradd.Birthday,
        //      Phone = useradd.Phone,
        //      FullName = useradd.FullName,
        //      TeudatZeut = useradd.TeudatZeut,
        //      UserName = useradd.UserName,
        //      Email = useradd.Email,
        //      Gender = useradd.Gender,
        //      Password = useradd.Password,
        //      IsValidUSer = useradd.IsValidUSer,
        //      PicPath = useradd.PicPath,
        //      TypeOfUser = typeofuser.UserType.TypeOfUser
        //    };
        //    IdentityResult identified = userManager.Create(uIdentity, useradd.Password);

        //    return true;

        //  }


        //}


        //public bool AddUser1(UserModel useradd)
        //{
        //  User newuser = db.Users.Where(a => a.UserID == useradd.UserID).FirstOrDefault();
        //  if (newuser != null)
        //  {
        //    return false;
        //  }
        //  User u = new User
        //  {
        //    FullName = useradd.FullName,
        //    TeudatZeut = useradd.TeudatZeut,
        //    UserName = useradd.UserName,
        //    Email = useradd.Email,
        //    Gender = useradd.Gender,
        //    Password = useradd.Password,
        //    IsValidUSer = useradd.IsValidUSer,
        //    PicPath = useradd.PicPath,
        //    Birthday = useradd.Birthday,
        //    UserTypeID = useradd.UserTypeID
        //  };

        //  try
        //  {
        //    db.Users.Add(u);
        //    db.SaveChanges();
        //    var typeofuser = db.Users.Where(x => x.UserType.UserTypeID == u.UserTypeID).FirstOrDefault();
        //    var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
        //    var userManager = new UserManager<ApplicationUser>(userStore);
        //    ApplicationUser uIdentity = new ApplicationUser
        //    {
        //      UserID = useradd.UserID,
        //      BirthDate = useradd.Birthday,
        //      FullName = useradd.FullName,
        //      TeudatZeut = useradd.TeudatZeut,
        //      UserName = useradd.UserName,
        //      Email = useradd.Email,
        //      Gender = useradd.Gender,
        //      Password = useradd.Password,
        //      IsValidUSer = useradd.IsValidUSer,
        //      PicPath = useradd.PicPath,
        //      TypeOfUser = typeofuser.UserType.TypeOfUser
        //    };
        //    IdentityResult identified = userManager.Create(uIdentity, useradd.Password);

        //    return true;

        //  }
        //  catch (Exception)
        //  {
        //    return false;
        //  }
        //}


        //public UserModel UpdateUser(UserModel ur, int id)
        //{
        //  if (id != ur.UserID)
        //  { return null; }
        //  else
        //  {
        //    if (id == ur.UserID)
        //    {
        //      var query = from u in db.Users select u;

        //      User user = query.FirstOrDefault();
        //      user.UserID = ur.UserID;
        //      user.UserName = ur.UserName;
        //      user.FullName = ur.FullName;
        //      user.TeudatZeut = ur.TeudatZeut;
        //      user.Password = ur.Password;
        //      user.Birthday = ur.Birthday;
        //      user.Email = ur.Email;
        //      user.Gender = ur.Gender;
        //      user.IsValidUSer = ur.IsValidUSer;
        //      user.PicPath = ur.PicPath;
        //      user.Phone = ur.Phone;

        //      user.UserTypeID = user.UserTypeID;
        //    }
        //  }
        //  db.SaveChanges();
        //  var typeofuser = db.Users.Where(x => x.UserType.UserTypeID == ur.UserTypeID).DefaultIfEmpty();
        //  var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
        //  var userManager = new UserManager<ApplicationUser>(userStore);
        //  ApplicationUser uIdentity = new ApplicationUser
        //  {
        //    UserID = ur.UserID,
        //    BirthDate = ur.Birthday,

        //    FullName = ur.FullName,
        //    TeudatZeut = ur.TeudatZeut,
        //    UserName = ur.UserName,
        //    Email = ur.Email,
        //    Gender = ur.Gender,
        //    Password = ur.Password,
        //    IsValidUSer = ur.IsValidUSer,
        //    PicPath = ur.PicPath,
        //    //TypeOfUser = typeofuser.UserType.TypeOfUser
        //  };
        //  IdentityResult identified = userManager.Create(uIdentity, ur.Password);
        //  return ur;
        //}

        private bool IsAvail(int Id)
        {
            User User = db.Users.FirstOrDefault(at => at.UserID == Id);

            if (User != null)
                return User.IsValidUSer;
            else
                return false;
        }


        public bool DeleteUser(int id)
        {
            try
            {
                using (CarRentalEntities db = new CarRentalEntities())
                {
                    User b = db.Users.Where(d => d.UserID == id).FirstOrDefault();
                    if (b != null)
                    {
                        db.Users.Remove(b);
                        db.SaveChanges();
                        return true;
                    }
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
    //public bool DeleteUser(int id)
    //{
    //  try
    //  {
    //    using (CarRentalEntities db = new CarRentalEntities())
    //    {
    //      User b = db.Users.Where(d => d.UserID == id).FirstOrDefault();
    //      if (b != null)
    //      {
    //        db.Users.Remove(b);
    //        db.SaveChanges();
    //        return true;
    //      }
    //    }
    //    return false;

    //  }
    //  catch (Exception)
    //  {
    //    return false;
    //  }






    //}

}







