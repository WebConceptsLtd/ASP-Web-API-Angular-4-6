
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    
    public class UserTypeModel
    {
         
        [Range(0, 999)]
        public int UserTypeID { get; set; }
        public string TypeOfUser { get; set; }

        public virtual IEnumerable<UserModel> Users { get; set; }
       
    }
}
