using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{

    public class CarModel
    {

        [Range(0, 999)]
        [Key]
        public int CarID { get; set; }

        [Required]
        public string CarNum { get; set; }

        [Required, Range(0, 300)]
        public int KM { get; set; }

        [MinLength(5), MaxLength(20)]
        public string CarPic { get; set; }

        [Required]
        public bool IsFix { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
        [Required, Range(0, 3000)]
        public int CarTypeID { get; set; }
        [Required, Range(1, 30)]
        public int BarnchID { get; set; }

        public CarTypeModel CarType { get; set; }

        public BranchModel Branch { get; set; }

    }
}
