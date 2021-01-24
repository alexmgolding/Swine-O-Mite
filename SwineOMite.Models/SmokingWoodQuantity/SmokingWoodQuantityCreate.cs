using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.SmookingWoodQuantity
{
    public class SmokingWoodQuantityCreate
    {
        [Key]
        public int SmokingWoodQuantityId { get; set; }
        [Key]
        public int SmokingWoodId { get; set; }
        [Key]
        public int WoodQuantityId { get; set; }
    }
}
