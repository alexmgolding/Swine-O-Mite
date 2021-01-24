using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.Ingredient
{
    public class IngredientDetail
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name ="Updated")]
        public DateTimeOffset? UpdatedUtc { get; set; }
    }
}
