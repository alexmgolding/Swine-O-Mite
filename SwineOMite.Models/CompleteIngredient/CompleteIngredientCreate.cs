using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.CompleteIngredient
{
    public class CompleteIngredientCreate
    {
        [Key]
        public int CompleteIngredientId { get; set; }
        [Key]
        public int IngredientId { get; set; }
        [Key]
        public int QuantityId { get; set; }
    }
}
