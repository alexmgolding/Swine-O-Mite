using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.WoodQuantity
{
    public class WoodQuantityListItem
    {
        [Display(Name = "Wood Quantity Id")]
        public int WoodQuantityId { get; set; }
        [Display(Name = "Wood Amount")]
        public int WoodAmount { get; set; }
    }
}
