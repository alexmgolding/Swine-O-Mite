using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models
{
    public class IngredientListItem
    {
        public int IngredientId { get; set; }
        [Display(Name ="Ingredient")]
        public string IngredientName { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
