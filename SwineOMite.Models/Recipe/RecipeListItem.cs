﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SwineOMite.Models.Recipe
{
    public class RecipeListItem
    {
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        //public DateTime DateCreated { get; set; }
        public ICollection<MultiSelectList> CompleteIngredient { get; set; }
        public ICollection<MultiSelectList> SmokingWoodQuantity { get; set; }
        public MultiSelectList Direction { get; set; }
        public string DirectionSteps { get; set; }
        //public virtual ICollection<SwineOMite.Data.Entities.CompleteIngredient> CompleteIngredients { get; set; } //= new List<CompleteIngredient>();
        //public virtual ICollection<SwineOMite.Data.Entities.SmokingWoodQuantity> SmokingWoodQuantities { get; set; } //= new List<SmokingWoodQuantity>();
        //public int DirectionId { get; set; }
    }
}
