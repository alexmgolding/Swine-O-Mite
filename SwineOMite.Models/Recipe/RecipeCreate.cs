using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwineOMite.Models.Recipe
{
    public class RecipeCreate
    {
        [Key]
        public int RecipeId { get; set; }
        public Guid RecipeOwner { get; set; }
        public string RecipeTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public string DirectionSteps { get; set; }
        public int SmokingWood { get; set; }
        public string FullIngredient { get; set; }
        //public virtual ICollection<CompleteIngredient> CompleteIngredients { get; set; } //= new List<CompleteIngredient>();
        //public virtual ICollection<SwineOMite.Data.Entities.SmokingWoodQuantity> SmokingWoodQuantities { get; set; } //= new List<SmokingWoodQuantity>();
        //[ForeignKey(nameof(Direction))]
        //public int DirectionId { get; set; }
        //public virtual Direction Direction { get; set; }
    }
}
