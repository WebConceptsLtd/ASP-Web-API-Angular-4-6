using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

using Microsoft.AspNet.Identity.EntityFramework;
namespace BO
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public int Birthday { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public string Password { get; set; }
        public int TeudatZeut { get; set; }
        public int UserTypeID { get; set; }
        public bool IsValidUSer { get; set; }
        public string PicPath { get; set; }
        //public string TypeOfUser { get; internal set; }
        public int UserID { get; set; }

        public string Phone { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //AspNetUsers -> User
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("User");
            //AspNetRoles -> Role
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");
            //AspNetUserRoles -> UserRole
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRole");
            //AspNetUserClaims -> UserClaim
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");
            //AspNetUserLogins -> UserLogin
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogin");
        }
    }

}
