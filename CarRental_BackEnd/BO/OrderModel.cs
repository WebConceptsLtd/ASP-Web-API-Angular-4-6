using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{

    [Table("Order")]

    public class OrderModel
    {
        [Key]
        [Range(0, 999)]
        public int OrderID { get; set; }

        [Required]

        public System.DateTime StartDate { get; set; }

        [Required]

        public System.DateTime FinishDate { get; set; }


        public Nullable<System.DateTime> Returned { get; set; }

        public int UserID { get; set; }

        public int CarID { get; set; }

        public UserModel User { get; set; }

        public CarModel Car { get; set; }
    }
}
