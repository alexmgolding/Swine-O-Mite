using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.CompleteIngredient
{
    public class CompleteIngredientDetail
    {
        public int CompleteIngredientId { get; set; }
        public int IngredientId { get; set; }
        public int QuantityId { get; set; }
    }
}
