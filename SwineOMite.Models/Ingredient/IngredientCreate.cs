using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.Ingredient
{
    public class IngredientCreate
    {
        [Required]
        [Display(Name = "Ingredient Name")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string IngredientName { get; set; }
    }
}
