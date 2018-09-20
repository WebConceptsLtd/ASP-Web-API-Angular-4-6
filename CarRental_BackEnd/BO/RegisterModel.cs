using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class RegisterModel
    {
       
     
        public int UserID { get; set; }


        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required]
        public string FullName { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
     
        public int UserTypeID { get; set; }
       
        public int TeudatZeut { get; set; }
    }
}
