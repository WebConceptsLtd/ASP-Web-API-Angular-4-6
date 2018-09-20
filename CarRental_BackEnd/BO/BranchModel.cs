using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
  public  class BranchModel
    {
        [Key]
        [Range(0, 999)]
        public int BranchID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        
        public decimal Latitude { get; set; }
       
        public decimal Longtitude { get; set; }

        public  CarModel Car { get; set; }
    }
}
