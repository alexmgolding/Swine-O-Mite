using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Data.Entities
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public Guid RecipeOwner { get; set; }
        public DateTime DateCreated { get; set; }
        public string RecipeTitle { get; set; }
        public virtual ICollection<CompleteIngredient> CompleteIngredients { get; set; } = new List<CompleteIngredient>();
        public virtual ICollection<SmokingWoodQuantity> SmokingWoodQuantities { get; set; } = new List<SmokingWoodQuantity>();
        public virtual ICollection<Direction> Directions { get; set; } = new List<Direction>();
    }
}
