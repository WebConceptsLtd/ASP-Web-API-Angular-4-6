using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{

    public class CarTypeModel
    {
        [Key]
        public int CarTypeID { get; set; }
       
        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        public decimal PriceExtraPerDay { get; set; }

        [Required, Range(0, 9999)]
        public int Year { get; set; }
        [Required]
        public bool IsManual { get; set; }

        public CarModel Car { get; set; }
    }
}
