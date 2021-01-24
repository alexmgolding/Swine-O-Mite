//using SwineOMite.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Data.Entities
{
    public enum MeasurementType
    {
        tsp = 1,
        T,
        C,
        oz,
        lb
    }
    public class IngredientQuantity
    {
        [Key]
        public int QuantityId { get; set; }
        [Required]
        public int IngredientAmount { get; set; }
        [Required]
        public MeasurementType MeasurementUnit { get; set; }
        //public virtual MeasurementType MeasurementUnit { get; set; }
    }
}
