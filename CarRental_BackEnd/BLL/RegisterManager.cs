using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RegisterManager 
    {

        public RegisterModel EditUserRgistrationForm(User user)
        {
            if (user.UserID == 1)
            {
                return new RegisterModel()
                {
                    Birthday = user.Birthday,
                    FullName = user.FullName,
                    Password = user.Password,
                    Gender = user.Gender,
                    UserName = user.UserName,
                    UserTypeID = user.UserTypeID
                };

            }
            else
                return new RegisterModel()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Gender = user.Gender,

                };
                    
        }
    }
}