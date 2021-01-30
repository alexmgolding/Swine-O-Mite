using SwineOMite.Data;
using SwineOMite.Data.Entities;
using SwineOMite.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SwineOMite.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;
        public RecipeService()
        {
            
        }

        public bool CreateRecipe(RecipeCreate model)
        {            
            var entity = new Recipe()
            {
                RecipeOwner = _userId,
                RecipeTitle = model.RecipeTitle,
                //DateCreated = model.DateCreated
                //CompleteIngredients = model.CompleteIngredients,
                //SmokingWoodQuantities = model.SmokingWoodQuantities,
                //DirectionId = model.DirectionId
            };

            var directionSteps = model.DirectionSteps.Split(',');
            var smokingWoodQuantity = model.SmokingWoodQuantityList;
            var completeIngredients = model.CompleteIngredientList;
            int loopCounter = 1;

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                ctx.SaveChanges();
                foreach (string directionStep in directionSteps)
                {
                    entity.Directions.Add(new Direction
                    {
                        StepNumber = loopCounter,
                        Instructions = directionStep
                    });
                    loopCounter++;
                }

            }
            return true; 
        }

        public MultiSelectList GetIngredientDropdown()
        {
            //var entity = new Recipe() { };
            //int loopCounter = 1;

            using (var ctx = new ApplicationDbContext())
            {
                
                var query = ctx
                    .CompleteIngredients
                    .Select(
                    ci => new
                    {
                        Value = ci.CompleteIngredientId,
                        Text = ci.Ingredient.IngredientName + ci.IngredientQuantity.IngredientAmount.ToString() + ci.IngredientQuantity.MeasurementUnit.ToString()
                    });

                //foreach (string ingredient in )
                //{
                //    var ingredientAmount = ctx.CompleteIngredients.Find()
                //        ions.Add(new Recipe
                //    {
                //        CompleteIngredients = 
                //        Instructions = directionStep
                //    });
                //    loopCounter++;
                //}
                return new MultiSelectList(query.ToArray(), "Value", "Text");
            }
        }

        public MultiSelectList GetSmokingWoodQuantityDropdown()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .SmokingWoodQuantities
                    .Select(
                    s => new
                    {
                        Value = s.SmokingWoodQuantityId,
                        Text = s.SmokingWood.WoodSpecies.ToString() + s.SmokingWood.WoodVariety.ToString() + s.WoodQuantity.WoodAmount.ToString()
                    });

                return new MultiSelectList(query.ToArray(), "Value", "Text");
            }
        }
        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Recipes
                    .Where(e => e.RecipeOwner == _userId)
                    .Select(
                    e => new RecipeListItem
                    {
                        RecipeId = e.RecipeId,
                        RecipeTitle = e.RecipeTitle,
                        //DateCreated = e.DateCreated,
                        //CompleteIngredients = e.CompleteIngredients,
                        //SmokingWoodQuantities = e.SmokingWoodQuantities,
                        //DirectionId = 0 //e.DirectionId
                    }
                    );

                return query.ToArray();
            }
        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Recipes
                    .Single(e => e.RecipeId == id && e.RecipeOwner == _userId);
                return
                    new RecipeDetail
                    {
                        RecipeId = entity.RecipeId,
                        RecipeTitle = entity.RecipeTitle,
                        //DateCreated = entity.DateCreated,
                        CompleteIngredients = entity.CompleteIngredients,
                        SmokingWoodQuantities = entity.SmokingWoodQuantities,
                        DirectionId = 0 //entity.DirectionId
                    };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Recipes
                    .Single(e => e.RecipeId == model.RecipeId && e.RecipeOwner == _userId);

                entity.RecipeTitle = model.RecipeTitle;
                entity.CompleteIngredients = model.CompleteIngredients;
                entity.SmokingWoodQuantities = model.SmokingWoodQuantities;
                //entity.DirectionId = model.DirectionId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Recipes
                    .Single(e => e.RecipeId == recipeId);

                ctx.Recipes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
