using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SwineOMite.Models.Recipe
{
    public class RecipeEdit
    {
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        //public DateTime DateCreated { get; set; }
        public string DirectionSteps { get; set; }
        public virtual ICollection<SwineOMite.Data.Entities.CompleteIngredient> CompleteIngredients { get; set; } //= new List<CompleteIngredient>();
        public MultiSelectList SelectedCompleteIngredientIds { get; set; }
        public virtual ICollection<SwineOMite.Data.Entities.SmokingWoodQuantity> SmokingWoodQuantities { get; set; } //= new List<SmokingWoodQuantity>();
        public MultiSelectList SelectedSmokingWoodQuantityIds { get; set; }
        public int DirectionId { get; set; }
    }
}
