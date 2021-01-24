//using SwineOMite.Models.Enums;
using SwineOMite.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.IngredientQuantities
{
    public class IngredientQuantityListItem
    {
        public int QuantityId { get; set; }
        [Display(Name = "Ingredient Amount")]
        public int IngredentAmount { get; set; }
        [Display(Name = "Ingredient Measurement")]
        public MeasurementType MeasurementUnit { get; set; }
        //public MeasurementType MeasurementType { get; set; }
    }
}
