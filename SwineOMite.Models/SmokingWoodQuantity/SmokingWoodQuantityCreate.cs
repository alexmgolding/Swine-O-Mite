using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SwineOMite.Models.SmokingWoodQuantity
{
    public class SmokingWoodQuantityCreate
    {
        [Key]
        public int SmokingWoodQuantityId { get; set; }
        [Key]
        public int SmokingWoodId { get; set; }
        public IEnumerable<SelectListItem> SmokingWood { get; set; }
        [Key]
        public int WoodQuantityId { get; set; }
        public IEnumerable<SelectListItem> WoodQuantity { get; set; }   
    }
}
