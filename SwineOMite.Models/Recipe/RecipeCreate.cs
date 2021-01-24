using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.Recipe
{
    public class RecipeCreate
    {
        [Key]
        public int RecipeId { get; set; }
        public DateTime DateCreated { get; set; }
        public string RecipeName { get; set; }
    }
}
