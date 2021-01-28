using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.Recipe
{
    public class RecipeDetail
    {
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<SwineOMite.Data.Entities.CompleteIngredient> CompleteIngredients { get; set; } //= new List<CompleteIngredient>();
        public virtual ICollection<SwineOMite.Data.Entities.SmokingWoodQuantity> SmokingWoodQuantities { get; set; } //= new List<SmokingWoodQuantity>();
        public int DirectionId { get; set; }
    }
}
