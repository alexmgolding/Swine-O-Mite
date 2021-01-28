using SwineOMite.Data;
using SwineOMite.Data.Entities;
using SwineOMite.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Services
{
    public class RecipeService
    {
        public RecipeService()
        {

        }

        public bool CreateRecipe(RecipeCreate model)
        {
            return true;
            var entity = new Recipe()
            {
                RecipeOwner = model.RecipeOwner,
                RecipeTitle = model.RecipeTitle,
                DateCreated = model.DateCreated
                //CompleteIngredients = model.CompleteIngredients,
                //SmokingWoodQuantities = model.SmokingWoodQuantities,
                //DirectionId = model.DirectionId
            };

            var directionSteps = model.DirectionSteps.Split(',');
            var smokingWood = model.SmokingWood;
            var fullIngredient = model.FullIngredient;
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
                //foreach (string fullIngredient in fullIngredient)
                {
                    // for every id they pick need to find the entity related to that entity (var needs to be inside foreach loop)
                    // if statement != null
                    // add to ICollection
                    //    entity.CompleteIngredients.Add(new CompleteIngredient
                    //    {
                    //        Ingredient = fullIngredient,
                    //        IngredientQuantity = IngredientQuantity
                    //    });
                    //}

                    //foreach (int smokingWood in smokingWood)
                    //{
                    //    entity.SmokingWoodQuantities.Add(new SmokingWoodQuantity
                    //    {
                    //        WoodQuantityId = smokingWood,

                    //    });
                    //}

                }
            }
        }
        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Recipes
                    //.Where(e => e.IngredientId = ingredientId)
                    .Select(
                    e => new RecipeListItem
                    {
                        RecipeId = e.RecipeId,
                        RecipeTitle = e.RecipeTitle,
                        DateCreated = e.DateCreated,
                        CompleteIngredients = e.CompleteIngredients,
                        SmokingWoodQuantities = e.SmokingWoodQuantities,
                        DirectionId = 0 //e.DirectionId
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
                    .Single(e => e.RecipeId == id);
                return
                    new RecipeDetail
                    {
                        RecipeId = entity.RecipeId,
                        RecipeTitle = entity.RecipeTitle,
                        DateCreated = entity.DateCreated,
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
                    .Single(e => e.RecipeId == model.RecipeId);

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
