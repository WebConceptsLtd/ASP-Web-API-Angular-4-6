using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Linq;
using System.Web;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace CarRental_BackEnd
{
    public class AuthContext: Microsoft.EntityFrameworkCore.DbContext
    {
      
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        public System.Data.Entity.DbSet<User> Users { get; set; }
      


    
}
}