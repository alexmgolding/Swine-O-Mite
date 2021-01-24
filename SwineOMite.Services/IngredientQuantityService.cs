using SwineOMite.Data;
using SwineOMite.Data.Entities;
using SwineOMite.Models.IngredientQuantities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Services
{
    public class IngredientQuantityService
    {
        public IngredientQuantityService()
        {

        }
        
        public bool CreateIngredientQuantity(IngredientQuantityCreate model)
        {
            var entity = new IngredientQuantity()
            {
                IngredientAmount = model.IngredentAmount,
                MeasurementUnit = model.MeasurementUnit
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IngredientQuantities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IngredientQuantityListItem> GetIngredientQuantity()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .IngredientQuantities
                    .Select(
                    e => new IngredientQuantityListItem
                    {
                        QuantityId = e.QuantityId,
                        IngredentAmount = e.IngredientAmount,
                        MeasurementUnit = e.MeasurementUnit
                    }
                    );

                return query.ToArray();
            }
        }

        public IngredientQuantityDetail GetIngredientQuantityById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .IngredientQuantities
                    .Single(e => e.QuantityId == id);
                return
                    new IngredientQuantityDetail
                    {
                        QuantityId = entity.QuantityId,
                        IngredentAmount = entity.IngredientAmount,
                        MeasurementUnit = entity.MeasurementUnit
                    };
            }
        }

        public bool UpdateIngredientQuantity(IngredientQuantityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .IngredientQuantities
                    .Single(e => e.QuantityId == model.QuantityId);

                entity.IngredientAmount = model.IngredentAmount;
                entity.MeasurementUnit = model.MeasurementUnit;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIngredientQuantity(int quantityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .IngredientQuantities
                    .Single(e => e.QuantityId == quantityId);

                ctx.IngredientQuantities.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}