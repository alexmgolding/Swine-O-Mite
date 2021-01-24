using SwineOMite.Data;
using SwineOMite.Models;
using SwineOMite.Models.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Services
{
    public class IngredientService
    {

        public IngredientService()
        {
            
        }

        public bool CreateIngredient(IngredientCreate model)
        {
            var entity = new Ingredient()
            {
                IngredientName = model.IngredientName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IngredientListItem> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Ingredients
                    //.Where(e => e.IngredientId = ingredientId)
                    .Select(
                    e => new IngredientListItem
                    {
                        IngredientId = e.IngredientId,
                        IngredientName = e.IngredientName
                    }
                    );

                return query.ToArray();
            }
        }

        public IngredientDetail GetIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Ingredients
                    .Single(e => e.IngredientId == id);
                return
                    new IngredientDetail
                    {
                        IngredientId = entity.IngredientId,
                        IngredientName = entity.IngredientName,
                        CreatedUtc = entity.CreatedUtc,
                        UpdatedUtc = entity.UpdatedUtc
                    };
            }
        }

        public bool UpdateIngredient(IngredientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Ingredients
                    .Single(e => e.IngredientId == model.IngredientId);

                entity.IngredientName = model.IngredientName;
                entity.UpdatedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIngredient(int ingredientId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Ingredients
                    .Single(e => e.IngredientId == ingredientId);
                
                ctx.Ingredients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
