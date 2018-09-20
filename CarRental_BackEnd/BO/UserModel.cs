
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Table("User")]
    public class UserModel
    {


        [Key]
        [Range(0, 999)]
        public int UserID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }

        [Required]
        public int TeudatZeut { get; set; }

        public int UserTypeID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime Birthday { get; set; }
        public bool IsValidUSer { get; set; }

        public string PicPath { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string LoggedOn { get; set; }
        public UserTypeModel UserType { get; set; }

        public OrderModel Order { get; set; }
    }
}
