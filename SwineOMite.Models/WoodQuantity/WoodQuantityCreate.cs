using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.WoodQuantity
{
    public class WoodQuantityCreate
    {
        [Key]
        public int WoodQuantityId { get; set; }
        [Required]
        public int WoodAmount { get; set; }
    }
}
