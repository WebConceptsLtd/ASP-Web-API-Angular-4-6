using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserTypeManager: DALBase
    {
        public List<UserTypeModel> GetTypeOfUser()
        {   
                return db.UserTypes.Select(a => new UserTypeModel
                {
                    TypeOfUser = a.TypeOfUser,
                    UserTypeID = a.UserTypeID
                }).ToList();


        }
   

        public void UpdateUserType(User uType)
        {
                db.Entry(uType).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
        
        }
    }
}
