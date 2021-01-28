using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.SmokingWoodQuantity
{
    public class SmokingWoodQuantityDetail
    {
        public int SmokingWoodQuantityId { get; set; }
        [Display(Name = "Smoking Wood Id")]
        public int SmokingWoodId { get; set; }
        [Display(Name = "Wood Quantity Id")]
        public int WoodQuantityId { get; set; }
    }
}
