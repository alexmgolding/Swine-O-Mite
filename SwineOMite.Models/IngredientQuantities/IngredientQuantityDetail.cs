//using SwineOMite.Models.Enums;
using SwineOMite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.IngredientQuantities
{
    public class IngredientQuantityDetail
    {
        public int QuantityId { get; set; }
        public int IngredentAmount { get; set; }
        public MeasurementType MeasurementUnit { get; set; }
        //public MeasurementType MeasurementType { get; set; }
    }
}
