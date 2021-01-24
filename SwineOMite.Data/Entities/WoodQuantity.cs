using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Data.Entities
{
    public class WoodQuantity
    {
        [Key]
        public int WoodQuantityId { get; set; }
        [Required]
        public int WoodAmount { get; set; }
        //[ForeignKey(nameof(SmokingWoodQuantity))]
        //public int SmokingWoodQuantityId { get; set; }
        //public virtual SmokingWoodQuantity SmokingWoodQuantity { get; set; }
    }
}