using SwineOMite.Data;
using SwineOMite.Data.Entities;
using SwineOMite.Models.CompleteIngredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Services
{
    public class CompleteIngredientService
    {
        public CompleteIngredientService()
        {

        }

        public bool CreateCompleteIngredient(CompleteIngredientCreate model)
        {
            var entity = new CompleteIngredient()
            {
                CompleteIngredientId = model.CompleteIngredientId,
                IngredientId = model.IngredientId,
                QuantityId = model.QuantityId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CompleteIngredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CompleteIngredientListItem> GetCompleteIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .CompleteIngredients
                    .Select(
                    e => new CompleteIngredientListItem
                    {
                        CompleteIngredientId = e.CompleteIngredientId,
                        IngredientId = e.IngredientId,
                        QuantityId = e.QuantityId
                    }
                    );

                return query.ToArray();
            }
        }

        public CompleteIngredientDetail GetCompleteIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .CompleteIngredients
                    .Single(e => e.CompleteIngredientId == id);
                return
                    new CompleteIngredientDetail
                    {
                        CompleteIngredientId = entity.CompleteIngredientId,
                        IngredientId = entity.IngredientId,
                        QuantityId = entity.QuantityId
                    };
            }
        }

        public bool UpdateCompleteIngredient(CompleteIngredientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .CompleteIngredients
                    .Single(e => e.CompleteIngredientId == model.CompleteIngredientId);

                entity.IngredientId = model.IngredientId;
                entity.QuantityId = model.QuantityId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCompleteIngredient(int completeIngredientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .CompleteIngredients
                    .Single(e => e.CompleteIngredientId == completeIngredientId);

                ctx.CompleteIngredients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}